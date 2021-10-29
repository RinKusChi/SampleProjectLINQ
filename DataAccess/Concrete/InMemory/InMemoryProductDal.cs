using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            // Oracle, MSSQL, MYSQL, Postgres, MongoDB'den geliyormuş gibi simüle ediyoruz.
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitInStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitInStock=3},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitInStock=2},
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitInStock=65},
            new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            #region _products.Remove neden çalışmaz?
            // _products.Remove(product); Bu şekilde ASLA çalışmaz.
            // Çünkü HEAP'te 5 tane adres var. Product'lar aynı referans numarasına sahip olmadığı için işlem yapamaz.
            // Değer tip olsaydı silerdi. Referans tipi silemezsin.
            #endregion          
            Product productToDelete = null;
            #region LINQ OLMASAYDI BU ŞEKİLDE KULLANACAKTIK...
            /*
             * 
            foreach (var p in _products)
            {
                if (product.ProductId==p.ProductId)
                {
                    productToDelete = p;
                }
            }*/
            #endregion

            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //SingleOrDefault tek bir eleman bulur. Product'u tek tek dolaşmaya yarar. p takma isim. ID bazlı yapılarda SingleOrDefault
            _products.Remove(productToDelete);


        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //WHERE KOŞULU İÇİNDEKİ ŞARTA UYAN BÜTÜN ELEMANLARI YENİ BİR LİSTE HALİNE GETİRİR VE ONU DÖNDÜRÜR.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
