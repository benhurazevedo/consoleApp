using consoleApp.Models;
using System;
using System.Linq;
using System.Collections.Generic;
namespace consoleApp.Services
{
    class DbService
    {
        private DB_LOJAContext dbContext;
        public DbService()
        {
            this.dbContext = new DB_LOJAContext();
        }
        public bool inserirProduto(Produtos produto)
        {   try {
                this.dbContext.Produtos.Add(produto);
                this.dbContext.SaveChanges();
                return true;
            }catch(Exception e){
                return false;
            }
        }
        public bool excluirProduto(int codigo)
        {
            try{
                Produtos produto = this.dbContext.Produtos.Find(codigo);
                if (produto == null) {
                    return false;
                }
                this.dbContext.Produtos.Remove(produto);
                this.dbContext.SaveChanges();
                return true;
            }catch(Exception e){
                return false;
            }
        }
        public bool alterarProduto (Produtos produto)
        {
            try {
                this.dbContext.Produtos.Update(produto);
                this.dbContext.SaveChanges();
                return true;
            }catch(Exception e){
                return false;
            }
        }
        public Produtos getProduto(int id)
        {
            try{
                return this.dbContext.Produtos.Find(id);
            }catch(Exception e){
                return null;
            }
            
        }
        public List<Produtos> listarProdutos()
        {
            try {
                return this.dbContext.Produtos.ToList();
            }catch(Exception e){
                return new List<Produtos>();
            }
        }
    }
}