using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    internal class ProducerBLL
    {
        private SupermarketDBEntities context = new SupermarketDBEntities();
        public string ErrorMessage { get; set; }

        public ObservableCollection<Producer> ProducersList { get; set; }

        public ObservableCollection<Producer> GetAllProducers()
        {
            var producers = context.Producers.ToList();
            var results=new ObservableCollection<Producer>();
            foreach (Producer prod in producers)
            {
                results.Add(prod);
            }
            return results;
        }
        public void UpdateProducer(object obj)
        {
            Producer producer = obj as Producer;
            if (producer == null)
            {
                ErrorMessage = "Trebuie sa selectati un producator!";
            }
            else
            {

                    context.ModifyProducer(producer.ProducerID, producer.Name,producer.Country, producer.IsActive);
                    context.SaveChanges();
                    ErrorMessage = "";

            }
        }
        public void AddProducer(object obj)
        {
            Producer producer = obj as Producer;
            if (producer != null)
            {
                if (string.IsNullOrEmpty(producer.Name))
                {
                    ErrorMessage = "Numele producatorului trebuie precizat!";
                }
                else
                if (context.Producers.FirstOrDefault(prod => prod.Name == producer.Name) != null)
                {
                    ErrorMessage = "Exista deja un producator cu acest nume!";
                }
                else
                {
                        producer.IsActive = true;
                        context.AddProducer(producer.Name, producer.Country, producer.IsActive, new ObjectParameter("producerID", producer.ProducerID));
                        context.SaveChanges();
                        producer.ProducerID = context.Producers.Max(a => a.ProducerID);
                        ProducersList.Add(producer);
                        ErrorMessage = "";
                }

            }
        }
        public void DeleteProducer(object obj)
        {

            Producer acc = obj as Producer;
            if (acc == null)
            {
                ErrorMessage = "Trebuie sa selectati un producator!";
            }
            else
            {
                acc.IsActive = false;
                context.DeleteAccount(acc.ProducerID, acc.IsActive);
                ProducersList.FirstOrDefault(context => context.ProducerID == acc.ProducerID).IsActive = false;
                context.SaveChanges();
                ErrorMessage = "";
            }
        }
    }
}
