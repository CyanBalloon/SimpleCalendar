﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleCalendar
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="db_SC")]
	public partial class db_SCContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttbItems(tbItems instance);
    partial void UpdatetbItems(tbItems instance);
    partial void DeletetbItems(tbItems instance);
    #endregion
		
		public db_SCContextDataContext() : 
				base(global::SimpleCalendar.Properties.Settings.Default.db_SCConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public db_SCContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public db_SCContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public db_SCContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public db_SCContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tbItems> tbItems
		{
			get
			{
				return this.GetTable<tbItems>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbItems")]
	public partial class tbItems : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_Item;
		
		private System.DateTime _date;
		
		private string _description;
		
		private int _color;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_ItemChanging(int value);
    partial void OnID_ItemChanged();
    partial void OndateChanging(System.DateTime value);
    partial void OndateChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OncolorChanging(int value);
    partial void OncolorChanged();
    #endregion
		
		public tbItems()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_Item", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID_Item
		{
			get
			{
				return this._ID_Item;
			}
			set
			{
				if ((this._ID_Item != value))
				{
					this.OnID_ItemChanging(value);
					this.SendPropertyChanging();
					this._ID_Item = value;
					this.SendPropertyChanged("ID_Item");
					this.OnID_ItemChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="Date NOT NULL")]
		public System.DateTime date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this.OndateChanging(value);
					this.SendPropertyChanging();
					this._date = value;
					this.SendPropertyChanged("date");
					this.OndateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_color", DbType="Int NOT NULL")]
		public int color
		{
			get
			{
				return this._color;
			}
			set
			{
				if ((this._color != value))
				{
					this.OncolorChanging(value);
					this.SendPropertyChanging();
					this._color = value;
					this.SendPropertyChanged("color");
					this.OncolorChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
