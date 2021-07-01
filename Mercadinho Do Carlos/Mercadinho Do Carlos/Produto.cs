using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho_Do_Carlos
{
    class Produto
    {
        private int codigo;
        private String nome;
        private String descricao;
        private float preco;
        private float porcentagem;


        public Produto(int codigo, String nome, String descricao, float preco, float porcentagem)
        {
          
            this.codigo = codigo;
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
            this.porcentagem = porcentagem;
        }


        public int getCodigo()
        {
            return codigo;
        }
        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }
        public String getNome()
        {
            return nome;
        }
        public void setNome(String nome)
        {
            this.nome = nome;
        }
        public String getDescricao()
        {
            return descricao;
        }
        public void setDescricao(String descricao)
        {
            this.descricao = descricao;
        }
        public float getPreco()
        {
            return preco;
        }
        public void setPreco(float preco)
        {
            this.preco = preco;
        }
        public float getPorcentagem()
        {
            return porcentagem;
        }
        public void setPorcentagem(float porcentagem)
        {
            this.porcentagem = porcentagem;
        }
    }
}
