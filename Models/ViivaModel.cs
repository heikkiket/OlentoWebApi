using System;
using System.Collections.Generic;

namespace OlentoWebApi.Models
{

	public class Vari {
        public uint Id {get;set;}
		public uint r {get;set;}
		public uint g {get;set;}
		public uint b {get;set;}
	}

	public class Siivu {
        public Vari vari {get;set;}
	}
	

	public class Viiva {
		public uint Id {get;set;}
		//public string nimi;
		//public string sarjan_nimi;
		public Vari kalibroinnin_vari {get;set;}
		//public float kalibroinnin_paksuus;
		//public float kalibroinnin_sumeus;
		public List<Siivu> siivut; 

	}
}
