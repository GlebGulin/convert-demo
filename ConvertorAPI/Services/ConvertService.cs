using Binding;
using Models.Entities.JsonToModel;
using Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Services
{
    public interface IConvertService
    {
        IEnumerable<HistoryConvert> GetHistory();
        IEnumerable<Currency> GetCurrencies();
        bool AddItemHistory(HistoryConvert model);
        Root ReturnRoot();
    }
    public class ConvertService : IConvertService
    {
        private readonly string jsonpath = "https://api.exchangeratesapi.io/latest?base=USD";
        private readonly ConvertContext _convertContext;
        public ConvertService(ConvertContext convertContext)
        {
            _convertContext = convertContext;
        }
        public IEnumerable<HistoryConvert> GetHistory()
        {
            var result = new List<HistoryConvert>();
            ////////////////////////////////////
            
            try
            {
                ///////////////////////////////////////////
                //Root result = JsonConvert.DeserializeObject<Root>(jsonconfiguration);

                //////////////////////////////////////////
                result = _convertContext.histories.ToList();


            }
            catch (System.Exception)
            {

            }
            return result;
        }
        public IEnumerable<Currency> GetCurrencies()
        {
            var result = new List<Currency>();
            try
            {
                result = _convertContext.currencies.ToList();


            }
            catch (System.Exception)
            {

            }
            return result;
        }
        
        ////////////
        public bool AddItemHistory(HistoryConvert model)
        {

            Currency currentCurrency = _convertContext.currencies.Where(x => x.Id.Equals(model.FromCurrencyId)).FirstOrDefault();
            Currency finishcurrency = _convertContext.currencies.Where(x=> x.Id.Equals(model.ToCurrencyId)).FirstOrDefault();
            string jsonpathfrom = "https://api.exchangeratesapi.io/latest?base="+currentCurrency.CurrencyName;
            WebClient web = new WebClient();
            Stream stream = web.OpenRead(jsonpathfrom);

            string jsonconfiguration;
            using (var reader = new StreamReader(stream))

            {
                jsonconfiguration = reader.ReadToEnd();
            }

            Root result = JsonConvert.DeserializeObject<Root>(jsonconfiguration);
            
           
            try
                {
                    _convertContext.Add(model);
                    _convertContext.SaveChanges();
                    
                }
                catch (System.Exception)
                {
                    return false;
                }
            return true;



        }
       
        public Root ReturnRoot()
        {
            WebClient web = new WebClient();
            Stream stream = web.OpenRead(jsonpath);

            string jsonconfiguration;
            using (var reader = new StreamReader(stream))
          
            {
                jsonconfiguration = reader.ReadToEnd();
            }
            
            try
            {
                
                Root result = JsonConvert.DeserializeObject<Root>(jsonconfiguration);
                return result;

               


            }
            catch (System.Exception)
            {
                return null;
            }
            //return Root;
        }

    }
}
