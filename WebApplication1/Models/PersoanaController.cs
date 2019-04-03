using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Models
{
    public class PersoanaController : ApiController
    {
        private List<Persoana> BazaDate()
        {
            var lista = new List<Persoana>();

            lista.Add(new Persoana()
            {
                Nume = "Barsan",
                Prenume = "Paul",
                DataNastere = new DateTime(2009, 02, 08),
                Adresa = null,
                CNP = "19875421326598"
                
            });
            lista.Add(new Persoana()
            {
                Nume = "Barnea",
                Prenume = "Paulina",
                DataNastere = new DateTime(2010, 06, 09),
                Adresa = null,
                CNP = "29875421326598",
                ID = 1          });

            lista.Add(new Persoana()
            {
                Nume = "Banica",
                Prenume = "Jan",
                DataNastere = new DateTime(2001, 06, 10),
                Adresa = null,
                CNP = "28775421326598",
                ID = 2

        });
            lista.Add(new Persoana()
            {
                Nume = "Bibina",
                Prenume = "Marina",
                DataNastere = new DateTime(1997, 07, 11),
                Adresa = null,
                CNP = "28875421326598",
             ID = 3

        });
            lista.Add(new Persoana()
            {
                Nume = "Badea",
                Prenume = "Maria",
                DataNastere = new DateTime(1996, 06, 11),
                Adresa = null,
                CNP = "28875421326598",
             ID = 4


        });

            return lista;
        }
        // GET: api/Persoana
        public IEnumerable<string> Get()
        {


            return new string[] { "value1", "value2" };
        }

        /*// GET: api/Persoana/5
         public string Get(int id)
         {
             return "value";
         }
         */
        // POST: api/Persoana
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Persoana/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Persoana/5
        public void Delete(int id)
        {

        }
         
        [HttpGet]
        public List<Persoana> PersoanaListaFctDeAn(int An, int An2)
        { var lista = new List<Persoana>();
            lista.Add(new Persoana() { Nume = "Barsan", Prenume = "Paul", DataNastere = new DateTime(2009, 02, 08), Adresa = null,
                CNP = "19875421326598" ,
                ID = 1
            });
            lista.Add(new Persoana()
            {
                Nume = "Barnea",
                Prenume = "Paulina",
                DataNastere = new DateTime(2010, 06, 09),
                Adresa = null,
                CNP = "29875421326598",
                ID = 2
            });

            lista.Add(new Persoana()
            {
                Nume = "Banica",
                Prenume = "Jan",
                DataNastere = new DateTime(2001, 06, 10),
                Adresa = null,
                CNP = "28775421326598",
                ID = 3
            });
            lista.Add(new Persoana()
            {
                Nume = "Bibina",
                Prenume = "Marina",
                DataNastere = new DateTime(1997, 07, 11),
                Adresa = null,
                CNP = "28875421326598",
                ID = 4
            });
            lista.Add(new Persoana()
            {
                Nume = "Badea",
                Prenume = "Maria",
                DataNastere = new DateTime(1996, 06, 11),
                Adresa = null,
                CNP = "28875421326598",
ID = 5

            });
            var rez = lista.Where(x => x.DataNastere.Year == An).ToList();
            return rez;
            /*http://localhost:57113/Api/Persoana/PersoanaListaFctDeAn?An=2010&An2=02*/
        }


        [HttpPost]
        public Boolean PersoanaAdauga(Persoana p)
        {
            bool rez = false;

            rez = true;
            return rez;
            /*http://localhost:57113/Api/Persoana/PersoanaAdauga*/
        }


        [HttpGet]
        public Persoana GetPersoana(string id)
        {
            var lista = BazaDate();

            Persoana p = lista.Where(x => x.CNP == id).FirstOrDefault();
            return p;
            /*http://localhost:57113/Api/Persoana/GetPersoana?id=28875421326598*/

        }
        [HttpGet]
        public List< Persoana> ListaPersoane()
        {
            var lista = BazaDate();
            return lista;

        }
        [HttpPut]
        public List< Persoana>  ModPersoana(int ID, Persoana p)
        { var lista = BazaDate();
            lista[ID] = p;
            return lista;
        }

        [HttpDelete]
        public List<Persoana> DeletePersoana(int ID)
            {
            var lista = BazaDate();
            lista.RemoveAt(ID);
            return lista;

        }
    }

    }



