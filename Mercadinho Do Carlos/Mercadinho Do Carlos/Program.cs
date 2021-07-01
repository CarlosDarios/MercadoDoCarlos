using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Mercadinho_Do_Carlos

{


    class Program
    {
        private ArrayList produtosestocados = new ArrayList();
        private ArrayList produtos = new ArrayList();
        private ArrayList clientes = new ArrayList();
        private bool clienteClub;
        private string linha;
        private float subTotal;
        private float total;
        private float valorRestante;
        private float valorFaturado = 0;
        private bool isRunning = true;
        private bool yes = true;
        private bool isRunninyes = true;
        static void Main(string[] args)
        {
            Program m = new Program();

            m.adicionaProdutoNoEstoque(1, "Coca-Cola", "Coca-Cola 2L", 5.99f, 0.05f);
            m.adicionaProdutoNoEstoque(2, "Guaraná", "Guaraná Antártica 2,5L", 7.99f, 0.05f);
            m.adicionaProdutoNoEstoque(3, "Doritos", "Salgadinho doritos de churrasco 400g", 9.99f, 0.05f);
            m.adicionaProdutoNoEstoque(4, "Ruffles", "Salgadinho ruffles de queijo 400g", 7.99f, 0.05f);
            m.adicionaProdutoNoEstoque(5, "Pizza congelada", "Pizza congelada de calabresa", 10.49f, 0.05f);
            m.adicionaProdutoNoEstoque(6, "Agua", "Agua Gelada", 2.49f, 0.05f);

            m.adicionarClientes("117.462.609-71", "Carlos");
            m.adicionarClientes("116.926.079-95", "Daniel");
            m.adicionarClientes("090.749.739-06", "Pedro Ivo");

            while (m.isRunninyes == true)
            {
                while (m.isRunning == true)
                {
                    if (m.yes == true)
                    {
                        m.bemVindoALoja();

                        m.pegaCliente();

                        if (m.clienteClub == false)
                        {
                            Console.WriteLine("Cliente não faz parte do club fato, sem vantagens");

                        }

                        m.mostraProdutosNoEstoque();

                    }
                    else
                    {
                        m.mostraProdutosNoEstoque();
                        m.yes = true;
                    }
                    while (m.yes == true)
                    {

                        foreach (Produto p in m.produtosestocados)
                        {
                            try
                            {
                                if (p.getCodigo() == Convert.ToInt32(m.linha))
                                {
                                    m.registraProduto(p.getCodigo(), p.getNome(), p.getDescricao(), p.getPreco(), p.getPorcentagem());
                                    m.subTotal += p.getPreco();
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Tentativa de ID falho");

                                m.yes = false;
                                {
                                    break;
                                }
                            }



                        }

                        if (m.yes == false)
                        {
                            break;
                        }

                        Console.WriteLine("Produto adicionado");
                        Console.WriteLine("Deseja adicionar mais produtos, Digite o Id ou aperte 0 para finalizar a compra");

                        m.linha = Console.ReadLine();

                        if (m.linha.Equals("0"))
                        {
                            m.yes = false;
                            m.isRunning = false;
                            break;
                        }

                    }



                }
                m.mostraProdutos();

                if (m.clienteClub == true)
                {
                    m.total = m.subTotal - (m.subTotal * 0.05f);
                }
                else if (m.clienteClub == false)
                {
                    m.total = m.subTotal;
                }

                Console.WriteLine("\nTotal a pagar (Com vantagens caso for cliente do club):\n" + "R$ " + m.total);
                Console.WriteLine("\nInsira o pagamento:");

                m.linha = Console.ReadLine();

                m.valorRestante = m.total - float.Parse(m.linha);

                if (m.valorRestante <= 0)
                {
                    m.valorFaturado += float.Parse(m.linha);

                    Console.WriteLine("1 - Próximo cliente");
                    Console.WriteLine("2 - Finalizar caixa");

                    m.linha = Console.ReadLine();

                    if (m.linha.Equals("1"))
                    {
                        Console.WriteLine("Compra finalizada");
                        Console.WriteLine("Valor total faturado: " + m.valorFaturado);
                        m.isRunninyes = true;
                        m.isRunning = true;
                        m.yes = true;

                        int c = m.produtos.Count;

                        for (int i = 0; i < c; i++)
                        {
                            m.produtos.RemoveAt(0);
                            // Console.WriteLine(i);
                            // Console.WriteLine("O tamamnho do Array é " + m.produtos.Count);
                        }

                        //Console.WriteLine("Fim do For " + m.produtos.Count);
                        m.subTotal = 0;
                        m.total = 0;

                        Console.WriteLine("-----------------------------------");
                    }
                    else if (m.linha.Equals("2"))
                    {
                        Console.WriteLine("Compra finalizada");
                        Console.WriteLine("Valor total faturado: " + m.valorFaturado);
                        Console.ReadLine();
                        m.isRunninyes = false;
                        m.isRunning = false;
                        m.yes = false;
                        
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Valor Insuficiente");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Insira um valor válido");
                    Console.WriteLine();

                }

            }
            
        }

        public void bemVindoALoja()
        {
            Console.WriteLine("Bem vindo a loja do Carlos");
            Console.WriteLine("Próximo cliente - digite o cpf para o clube de vantagens");
        }

        public void adicionaProdutoNoEstoque(int codigo, String nome, String descricao, float preco, float porcentagem)
        {
            Produto p = new Produto(codigo, nome, descricao, preco, porcentagem);

            produtosestocados.Add(p);
   
        }
        public void mostraProdutosNoEstoque()
        {
            Console.WriteLine("Produtos:\n");

            foreach (Produto p in produtosestocados)
            {
                Console.WriteLine(p.getCodigo() + " | " + p.getNome() + " | " + p.getDescricao() + " | " + p.getPreco());

            }

            Console.WriteLine("Insira o código do produto");
            linha = Console.ReadLine();

            

        }
        public void registraProduto(int codigo, String nome, String descricao, float preco, float porcentagem)
        {
            Produto p = new Produto(codigo, nome, descricao, preco, porcentagem);

            produtos.Add(p);

        }
        public void mostraProdutos()
        {
            Console.WriteLine("Produtos comprados:");

            foreach (Produto p in produtos)
            {
                Console.WriteLine(p.getCodigo() + " | " + p.getNome() + " | " + p.getDescricao() + " | " + p.getPreco());

            }
            Console.WriteLine("\nSubTotal:\n" + "R$ " + subTotal);
        }

        public void adicionarClientes(String cpf, String nome)
        {
            Cliente c = new Cliente(cpf, nome);

            clientes.Add(c);

        }

        public void pegaCliente()
        {
            linha = Console.ReadLine();

            foreach (Cliente c in clientes)
            {
                if (linha.Equals(c.getCpf()))
                {
                    clienteClub = true;
                    Console.WriteLine("\n" + c.getNome() + " | " + c.getCpf());
                    break;

                }
            }

        }









    }
}

