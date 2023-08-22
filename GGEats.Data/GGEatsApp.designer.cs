﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GGEats.Data
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="GGEats")]
	public partial class GGEatsAppDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDetalle(Detalle instance);
    partial void UpdateDetalle(Detalle instance);
    partial void DeleteDetalle(Detalle instance);
    partial void InsertOrdene(Ordene instance);
    partial void UpdateOrdene(Ordene instance);
    partial void DeleteOrdene(Ordene instance);
    #endregion
		
		public GGEatsAppDataContext() : 
				base(global::GGEats.Data.Properties.Settings.Default.GGEatsConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public GGEatsAppDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GGEatsAppDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GGEatsAppDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GGEatsAppDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Detalle> Detalles
		{
			get
			{
				return this.GetTable<Detalle>();
			}
		}
		
		public System.Data.Linq.Table<Ordene> Ordenes
		{
			get
			{
				return this.GetTable<Ordene>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Detalles")]
	public partial class Detalle : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Id;
		
		private string _OrdenId;
		
		private string _Order_Id;
		
		private string _Product_Id;
		
		private decimal _Precio;
		
		private decimal _Impuesto;
		
		private int _Cantidad;
		
		private decimal _Total_Linea;
		
		private decimal _SubTotal;
		
		private string _Nombre;
		
		private string _Sku;
		
		private EntityRef<Ordene> _Ordene;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(string value);
    partial void OnIdChanged();
    partial void OnOrdenIdChanging(string value);
    partial void OnOrdenIdChanged();
    partial void OnOrder_IdChanging(string value);
    partial void OnOrder_IdChanged();
    partial void OnProduct_IdChanging(string value);
    partial void OnProduct_IdChanged();
    partial void OnPrecioChanging(decimal value);
    partial void OnPrecioChanged();
    partial void OnImpuestoChanging(decimal value);
    partial void OnImpuestoChanged();
    partial void OnCantidadChanging(int value);
    partial void OnCantidadChanged();
    partial void OnTotal_LineaChanging(decimal value);
    partial void OnTotal_LineaChanged();
    partial void OnSubTotalChanging(decimal value);
    partial void OnSubTotalChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnSkuChanging(string value);
    partial void OnSkuChanged();
    #endregion
		
		public Detalle()
		{
			this._Ordene = default(EntityRef<Ordene>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="NVarChar(450) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrdenId", DbType="NVarChar(450)")]
		public string OrdenId
		{
			get
			{
				return this._OrdenId;
			}
			set
			{
				if ((this._OrdenId != value))
				{
					if (this._Ordene.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOrdenIdChanging(value);
					this.SendPropertyChanging();
					this._OrdenId = value;
					this.SendPropertyChanged("OrdenId");
					this.OnOrdenIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Order_Id", DbType="NVarChar(MAX)")]
		public string Order_Id
		{
			get
			{
				return this._Order_Id;
			}
			set
			{
				if ((this._Order_Id != value))
				{
					this.OnOrder_IdChanging(value);
					this.SendPropertyChanging();
					this._Order_Id = value;
					this.SendPropertyChanged("Order_Id");
					this.OnOrder_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_Id", DbType="NVarChar(MAX)")]
		public string Product_Id
		{
			get
			{
				return this._Product_Id;
			}
			set
			{
				if ((this._Product_Id != value))
				{
					this.OnProduct_IdChanging(value);
					this.SendPropertyChanging();
					this._Product_Id = value;
					this.SendPropertyChanged("Product_Id");
					this.OnProduct_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Precio", DbType="Decimal(18,2) NOT NULL")]
		public decimal Precio
		{
			get
			{
				return this._Precio;
			}
			set
			{
				if ((this._Precio != value))
				{
					this.OnPrecioChanging(value);
					this.SendPropertyChanging();
					this._Precio = value;
					this.SendPropertyChanged("Precio");
					this.OnPrecioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Impuesto", DbType="Decimal(18,2) NOT NULL")]
		public decimal Impuesto
		{
			get
			{
				return this._Impuesto;
			}
			set
			{
				if ((this._Impuesto != value))
				{
					this.OnImpuestoChanging(value);
					this.SendPropertyChanging();
					this._Impuesto = value;
					this.SendPropertyChanged("Impuesto");
					this.OnImpuestoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int NOT NULL")]
		public int Cantidad
		{
			get
			{
				return this._Cantidad;
			}
			set
			{
				if ((this._Cantidad != value))
				{
					this.OnCantidadChanging(value);
					this.SendPropertyChanging();
					this._Cantidad = value;
					this.SendPropertyChanged("Cantidad");
					this.OnCantidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Total_Linea", DbType="Decimal(18,2) NOT NULL")]
		public decimal Total_Linea
		{
			get
			{
				return this._Total_Linea;
			}
			set
			{
				if ((this._Total_Linea != value))
				{
					this.OnTotal_LineaChanging(value);
					this.SendPropertyChanging();
					this._Total_Linea = value;
					this.SendPropertyChanged("Total_Linea");
					this.OnTotal_LineaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubTotal", DbType="Decimal(18,2) NOT NULL")]
		public decimal SubTotal
		{
			get
			{
				return this._SubTotal;
			}
			set
			{
				if ((this._SubTotal != value))
				{
					this.OnSubTotalChanging(value);
					this.SendPropertyChanging();
					this._SubTotal = value;
					this.SendPropertyChanged("SubTotal");
					this.OnSubTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="NVarChar(MAX)")]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sku", DbType="NVarChar(MAX)")]
		public string Sku
		{
			get
			{
				return this._Sku;
			}
			set
			{
				if ((this._Sku != value))
				{
					this.OnSkuChanging(value);
					this.SendPropertyChanging();
					this._Sku = value;
					this.SendPropertyChanged("Sku");
					this.OnSkuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Ordene_Detalle", Storage="_Ordene", ThisKey="OrdenId", OtherKey="Id", IsForeignKey=true)]
		public Ordene Ordene
		{
			get
			{
				return this._Ordene.Entity;
			}
			set
			{
				Ordene previousValue = this._Ordene.Entity;
				if (((previousValue != value) 
							|| (this._Ordene.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Ordene.Entity = null;
						previousValue.Detalles.Remove(this);
					}
					this._Ordene.Entity = value;
					if ((value != null))
					{
						value.Detalles.Add(this);
						this._OrdenId = value.Id;
					}
					else
					{
						this._OrdenId = default(string);
					}
					this.SendPropertyChanged("Ordene");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Ordenes")]
	public partial class Ordene : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Id;
		
		private string _Fecha;
		
		private decimal _Total;
		
		private decimal _SubTotal;
		
		private decimal _Impuesto;
		
		private string _Product_Id;
		
		private bool _Importado;
		
		private bool _Procesada;
		
		private EntitySet<Detalle> _Detalles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(string value);
    partial void OnIdChanged();
    partial void OnFechaChanging(string value);
    partial void OnFechaChanged();
    partial void OnTotalChanging(decimal value);
    partial void OnTotalChanged();
    partial void OnSubTotalChanging(decimal value);
    partial void OnSubTotalChanged();
    partial void OnImpuestoChanging(decimal value);
    partial void OnImpuestoChanged();
    partial void OnProduct_IdChanging(string value);
    partial void OnProduct_IdChanged();
    partial void OnImportadoChanging(bool value);
    partial void OnImportadoChanged();
    partial void OnProcesadaChanging(bool value);
    partial void OnProcesadaChanged();
    #endregion
		
		public Ordene()
		{
			this._Detalles = new EntitySet<Detalle>(new Action<Detalle>(this.attach_Detalles), new Action<Detalle>(this.detach_Detalles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="NVarChar(450) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="NVarChar(MAX)")]
		public string Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this.OnFechaChanging(value);
					this.SendPropertyChanging();
					this._Fecha = value;
					this.SendPropertyChanged("Fecha");
					this.OnFechaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Total", DbType="Decimal(18,2) NOT NULL")]
		public decimal Total
		{
			get
			{
				return this._Total;
			}
			set
			{
				if ((this._Total != value))
				{
					this.OnTotalChanging(value);
					this.SendPropertyChanging();
					this._Total = value;
					this.SendPropertyChanged("Total");
					this.OnTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubTotal", DbType="Decimal(18,2) NOT NULL")]
		public decimal SubTotal
		{
			get
			{
				return this._SubTotal;
			}
			set
			{
				if ((this._SubTotal != value))
				{
					this.OnSubTotalChanging(value);
					this.SendPropertyChanging();
					this._SubTotal = value;
					this.SendPropertyChanged("SubTotal");
					this.OnSubTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Impuesto", DbType="Decimal(18,2) NOT NULL")]
		public decimal Impuesto
		{
			get
			{
				return this._Impuesto;
			}
			set
			{
				if ((this._Impuesto != value))
				{
					this.OnImpuestoChanging(value);
					this.SendPropertyChanging();
					this._Impuesto = value;
					this.SendPropertyChanged("Impuesto");
					this.OnImpuestoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_Id", DbType="NVarChar(MAX)")]
		public string Product_Id
		{
			get
			{
				return this._Product_Id;
			}
			set
			{
				if ((this._Product_Id != value))
				{
					this.OnProduct_IdChanging(value);
					this.SendPropertyChanging();
					this._Product_Id = value;
					this.SendPropertyChanged("Product_Id");
					this.OnProduct_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Importado", DbType="Bit NOT NULL")]
		public bool Importado
		{
			get
			{
				return this._Importado;
			}
			set
			{
				if ((this._Importado != value))
				{
					this.OnImportadoChanging(value);
					this.SendPropertyChanging();
					this._Importado = value;
					this.SendPropertyChanged("Importado");
					this.OnImportadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Procesada", DbType="Bit NOT NULL")]
		public bool Procesada
		{
			get
			{
				return this._Procesada;
			}
			set
			{
				if ((this._Procesada != value))
				{
					this.OnProcesadaChanging(value);
					this.SendPropertyChanging();
					this._Procesada = value;
					this.SendPropertyChanged("Procesada");
					this.OnProcesadaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Ordene_Detalle", Storage="_Detalles", ThisKey="Id", OtherKey="OrdenId")]
		public EntitySet<Detalle> Detalles
		{
			get
			{
				return this._Detalles;
			}
			set
			{
				this._Detalles.Assign(value);
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
		
		private void attach_Detalles(Detalle entity)
		{
			this.SendPropertyChanging();
			entity.Ordene = this;
		}
		
		private void detach_Detalles(Detalle entity)
		{
			this.SendPropertyChanging();
			entity.Ordene = null;
		}
	}
}
#pragma warning restore 1591
