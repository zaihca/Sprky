using System;
using SparkDotNet;

namespace Sparky
{

public sealed class SparkInstance
{
	private static SparkInstance instance = null;
	private static readonly object padlock = new object();
		public Spark Sparkey
		{
			get;
			set;
		}

		private SparkInstance()
		{
			Sparkey= new Spark("MDliN2FjMGEtOGUyYS00NDRmLWFiODEtMDNkYjY1ZDEzZDE1ZGI0NTk2ZTgtNzgw");
		}

	public static SparkInstance Instance
	{
		get
		{
			lock (padlock)
			{
				if (instance == null)
				{
					instance = new SparkInstance();
				}
				return instance;
			}
		}
	}
}
}
