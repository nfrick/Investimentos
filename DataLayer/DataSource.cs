using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DataLayer {
    public partial class DataSource : Component, IListSource {
        // ** fields
        EFWinforms.EntityDataSource _ds;
        //const string DATABASEFILE = @"D:\Users\nfric\Documents\Visual Studio 2015\Projects\EF6Winforms\Sample\NORTHWND.MDF";
        //const string CONNECTIONSTRING =
        //    @"metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;" +
        //    @"provider connection string=""Data Source=.\SQLEXPRESS;AttachDbFilename=" + DATABASEFILE + ";" +
        //    @"Integrated Security=True;Connect Timeout=30;User Instance=True;MultipleActiveResultSets=True""";

        // ** ctors
        public DataSource() {
            InitializeComponent();

            // check that the database file exists
            //if (!System.IO.File.Exists(DATABASEFILE))
            //{
            //    throw new Exception("Database file not found. This sample requires the NorthWind database at " + DATABASEFILE);
            //}

            // create entity data source
            _ds = new EFWinforms.EntityDataSource();

            // create object context (specifying the connection string)
            _ds.DbContext = new InvestimentosEntities();  // CONNECTIONSTRING);
        }
        public DataSource(IContainer container) : this() {
            container.Add(this);
        }

        // ** object model
        public void SaveChanges() {
            // any logic/validation you want
            // ...

            // save the changes if everything is OK
            _ds.SaveChanges();
        }

        // ** IListSource
        bool IListSource.ContainsListCollection {
            get { return true; }
        }
        System.Collections.IList IListSource.GetList() {
            return ((IListSource)_ds).GetList();
        }
    }
}
