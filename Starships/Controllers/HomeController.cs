using Newtonsoft.Json;
using Starships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Starships.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Method of HomePage
        /// </summary>
        /// <returns>return View()</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Submit of Calculate button
        /// </summary>
        /// <param name="form"></param>
        /// <returns>View(listResultDTO)</returns>
        [HttpPost]
        public ActionResult Result(FormCollection form)
        {
            GridResultDTO listResultDTO = Search(form["txtDistance"]);
            if (listResultDTO == null)
                return RedirectToAction("Index", "Home");

            return View(listResultDTO);
        }

        /// <summary>
        /// Method of HomePage
        /// </summary>
        /// <returns></returns>
        public ActionResult ScriptVersion()
        {
            return View();
        }

        /// <summary>
        /// Method search the date in enum with the return of rest
        /// </summary>
        /// <param name="number"></param>
        /// <param name="strtime"></param>
        /// <returns>Convert.ToInt32(msg.StringDescription)</returns>
        public int getDays(int number, string strtime)
        {
            var msg = Utils.GetListEnum(typeof(Dias)).Where(w => w.Name == strtime).FirstOrDefault();
            return Convert.ToInt32(msg.StringDescription);
        }

        /// <summary>
        /// Add in list result
        /// </summary>
        /// <param name="MGLTView"></param>
        /// <param name="listResultDTO"></param>
        /// <param name="starshipsDTO"></param>
        /// <returns>listResultDTO</returns>
        public List<ResultDTO> addResultDTO(string MGLTView, List<ResultDTO> listResultDTO, GridDTO starshipsDTO)
        {
            foreach (var item in starshipsDTO.results)
            {
                ResultDTO resultDTO = new ResultDTO();
                string name = item.name;
                string consumables = item.consumables;
                int MGLT = 0;
                int stops = 0;
                if (item.MGLT != "unknown")
                    MGLT = Convert.ToInt32(item.MGLT);

                string[] consumablesSplit = consumables.Split(' ');
                if (consumablesSplit.Length == 2 && MGLT != 0)
                {
                    int number = Convert.ToInt32(consumablesSplit[0]);
                    string strTime = consumablesSplit[1];
                    int consumablesDays = getDays(number, strTime);

                    stops = Convert.ToInt32(Convert.ToInt32(MGLTView) / (number * consumablesDays * 24 * MGLT));
                }

                resultDTO.name = item.name;
                resultDTO.value = stops;
                listResultDTO.Add(resultDTO);
            }

            return listResultDTO;
        }

        /// <summary>
        /// API post rest the url
        /// </summary>
        /// <param name="MGLTView"></param>
        /// <returns>gridResultDTO</returns>
        public GridResultDTO Search(string MGLTView)
        {
            string url = "http://swapi.co/api/starships/?page=1";
            Rest rest = new Rest();
            GridDTO starshipsDTO = rest.SendRequestion(url);

            GridResultDTO gridResultDTO = new GridResultDTO();
            if (starshipsDTO == null)
                return gridResultDTO;

            List<ResultDTO> listResultDTO = new List<ResultDTO>();

            addResultDTO(MGLTView, listResultDTO, starshipsDTO);

            for (int i = 0; i < Convert.ToInt32(starshipsDTO.count) / 10; i++)
            {
                if (!string.IsNullOrEmpty(starshipsDTO.next))
                {
                    starshipsDTO = rest.SendRequestion(starshipsDTO.next);
                    if (starshipsDTO != null)
                        addResultDTO(MGLTView, listResultDTO, starshipsDTO);
                }
            }

            gridResultDTO.MGLTView = MGLTView;
            gridResultDTO.count = starshipsDTO.count;
            gridResultDTO.next = starshipsDTO.next;
            gridResultDTO.previous = starshipsDTO.previous;
            gridResultDTO.resultDTO = listResultDTO;

            return gridResultDTO;
        }
    }
}