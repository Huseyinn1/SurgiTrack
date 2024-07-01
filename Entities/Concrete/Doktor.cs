﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Doktor : IEntity
    {
        public int Id { get; set; }       
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public char Cinsiyet { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public DateTime KayitTarihi { get; set; }

    } 
    
}
