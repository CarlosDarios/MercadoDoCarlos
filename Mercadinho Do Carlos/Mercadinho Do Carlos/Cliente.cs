using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho_Do_Carlos
{
    class Cliente
    {
        private String cpf;
        private String nome;


        public Cliente(String cpf, String nome)
        {
            this.cpf = cpf;
            this.nome = nome;

        }


        public String getCpf()
        {
            return cpf;
        }
        public void setCpf(String cpf)
        {
            this.cpf = cpf;
        }
        public String getNome()
        {
            return nome;
        }
        public void setNome(String nome)
        {
            this.nome = nome;
        }
    }
}
