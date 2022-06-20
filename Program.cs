using CADASTRODEPESSOAFS.Classes;
Console.Clear();

Console.WriteLine(@$"
*********************************************
***   Bem Vindo ao sistema de cadastro!   ***
*********************************************
");
Thread.Sleep(1000);

BarraCarregamento("Carregando", 300);

List<PessoaFisica> listaPf = new List<PessoaFisica>();
// List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;
do{
    Console.Clear();
    Console.WriteLine(@$"
*********************************************
***     Escolha um das opções abaixo      ***
***---------------------------------------***
***         1 - Pessoa Física             ***
***         2 - Pessoa Juridica           ***
***                                       ***
***         0 - Sair                      ***
*********************************************
    ");

    opcao = Console.ReadLine();

    if(opcao == "1" || opcao == "Pessoa Fisica" || opcao == "pessoa fisica" || opcao == "pessoa física" || opcao == "Pessoa Física" || opcao == "1 - Pessoa Física")
    {
        BarraCarregamento("Carregando", 300);
        string? opcaoPf;
        do{
            Console.Clear();
            Console.WriteLine(@$"
*********************************************
***     Escolha um das opções abaixo      ***
***---------------------------------------***
***       1 - Cadatrar Pessoa Física      ***
***       2 - Listar Pessoas Físicas      ***
***                                       ***
***       0 - Voltar ao menu anterior     ***
*********************************************
    ");
            
            opcaoPf = Console.ReadLine();
            PessoaFisica metodoPf = new PessoaFisica();
            if (opcaoPf == "1" || opcaoPf == "Cadastar" || opcaoPf == "1 - Cadastar Pessoa Fisica" || opcaoPf == "cadastar pessoa fisica" || opcaoPf == "cadastar pessoa física" || opcaoPf == "Cadastar Pessoa Física")
            {
                Console.Clear();
                PessoaFisica novaPf = new PessoaFisica();
                Endereco novoEnd = new Endereco();

                Console.WriteLine($"Digite o nome da pessoa que deseja cadastrar");
                novaPf.nome = Console.ReadLine();

                bool cpfValido;
                do{
                    Console.WriteLine($"Digite o CPF Ex: 000.000.000-00 ou 00000000000");
                    string? cpf = Console.ReadLine();

                    cpfValido = metodoPf.ValidarCpf(cpf);
                    if(cpfValido){
                        novaPf.cpf = cpf;
                    }else{
                        Console.WriteLine($"cpf digitada invalida, digite cpf no formatovalido");
                    }
                } while (cpfValido == false);


                bool dataValida;
                do{

                    Console.WriteLine($"Digite a data de nascimento Ex: DD/MM/AAAA");
                    string? dataNasc = Console.ReadLine();
                    
                    dataValida = metodoPf.ValidarDataNascimento(dataNasc);
                    
                    if(dataValida){
                        novaPf.dataNasc = dataNasc;
                    }else{
                        Console.WriteLine($"Data digitada invalida, digite uma data valida");
                    }
                } while (dataValida == false);

                Console.WriteLine($"Digite o rendimento mensal (Digite apenas numeros)");
                novaPf.rendimento = float.Parse(Console.ReadLine());
               

                Console.WriteLine($"Digite o logradouro (nome da rua, avenida, travessa e etc..)");
                novoEnd.logradouro = Console.ReadLine();

                Console.WriteLine($"Digite o Numero");
                novoEnd.numero = int.Parse(Console.ReadLine());

                Console.WriteLine($"Digite o CEP (apenas numeros)");
                novoEnd.cep = int.Parse(Console.ReadLine());

                Console.WriteLine($"Este endereços é comercial? S/N");
                string endCom = Console.ReadLine();
                if(endCom == "S"){
                    novoEnd.endComercial = true;
                }else{
                    novoEnd.endComercial = false;
                }
        
                novaPf.endereco = novoEnd;

                // listaPf.Add(novaPf);

                using (StreamWriter sw = new StreamWriter($"teste\\{novaPf.cpf}.txt"))
                {
                    sw.WriteLine($"Nome: {novaPf.nome}");
                    sw.WriteLine($"CPF: {novaPf.cpf}");
                    sw.WriteLine($"Data de Nascimento: {novaPf.dataNasc:d}");
                    sw.WriteLine($"Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}, {novaPf.endereco.cep}");
                    sw.WriteLine($"Redimento: {novaPf.rendimento.ToString("C")}");
                    sw.WriteLine($"Taxa de imposto a ser pago é: {metodoPf.PagarImposto(novaPf.rendimento).ToString("C")}");
                }

                BarraCarregamento("Cadastro Realiado com Sucesso", 300);
                
            }else if(opcaoPf == "2" || opcaoPf == "Listar" || opcaoPf == "2 - Listar Pessoas Fisicas" || opcaoPf == "listar pessoas fisicas" || opcaoPf == "listar pessoa física" || opcaoPf == "Listar Pessoas Físicas"){
                Console.Clear();
                string[] arquivos = Directory.GetFiles("teste/");
                Console.WriteLine("Arquivos:");
                foreach (string arq in arquivos)
                {
                    string nomeArquivo = arq.Split("/")[1];
                    Console.WriteLine(nomeArquivo.Split(".")[0]);
                }

                Console.WriteLine($"Digite o CPF pasa consultar seu o cadastro (somente numeros");
                string arquivoPf = Console.ReadLine();

                    if(File.Exists($"teste/{arquivoPf}.txt"))
                    {
                        Console.Clear();
                        using(var reader = new StreamReader($"teste/{arquivoPf}.txt"))
                        {
                            string? linhaPf;
                            while((linhaPf = reader.ReadLine()) != null)
                            {
                                Console.WriteLine($"{linhaPf}");
                                
                            }   
                        }
                        Console.WriteLine($"Aperte 'ENTER' para retorna ao menu anterior");
                        Console.ReadLine();
                    }else{
                        BarraCarregamento("Pessoa não encontrado", 1000);
                    }

//                 if(listaPf.Count > 0){
//                     foreach(PessoaFisica cadaPessoa in listaPf){
//                         Console.WriteLine(@$"
// Nome: {cadaPessoa.nome}
// CPF: {cadaPessoa.cpf}
// Data de Nascimento: {cadaPessoa.dataNasc:d} 
// Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}, {cadaPessoa.endereco.cep}
// Redimento: {cadaPessoa.rendimento.ToString("C")}
// Taxa de imposto a ser pago é: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
// ");

//                         Console.WriteLine($"Aperte 'ENTER' para retorna ao menu anterior");
//                         Console.ReadLine();
//                     }
//                 }else{
//                     Console.WriteLine($"Lista Vazia!");
//                     Thread.Sleep(1000);
                    
//                 }
            }else if(opcaoPf == "0" || opcaoPf == "Voltar" || opcaoPf == "0 - Voltar ao menu anterior" || opcaoPf == "Voltar ao menu anterior" || opcaoPf == "voltar ao menu anterior"){
                BarraCarregamento("Carregando", 1000);
            } else {
                Console.WriteLine($"Comando invalido, escolha uma opção valida!");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }while(opcaoPf != "0");
  

    } else if (opcao == "2" || opcao == "2 - Pessoa Juridica" || opcao == "Pessoa Juridica" || opcao == "pessoa juridica")
    {
        BarraCarregamento("Carregando", 300);
        PessoaJuridica metodoPj = new PessoaJuridica();
        PessoaJuridica novaPj = new PessoaJuridica();
        Endereco novoEndPj = new Endereco();
        string? opcaoPj;
        do
        {
            Console.Clear();
            Console.WriteLine(@$"
*********************************************
***     Escolha um das opções abaixo      ***
***---------------------------------------***
***       1 - Cadatrar Pessoa Jurídica    ***
***       2 - Listar Pessoas Jurídica     ***
***                                       ***
***       0 - Voltar ao menu anterior     ***
*********************************************
    ");
            
            opcaoPj = Console.ReadLine();
            if(opcaoPj == "1" || opcaoPj == "Cadastrar" || opcaoPj == "cadastrar" || opcaoPj == "Cadastrar Pessoa Juridica" || opcaoPj == "Cadastrar Pessoa Jurídica" || opcaoPj == "1 - Cadastrar Pessoa Juridica" || opcaoPj == "cadastrar pessoa juridica" || opcaoPj == "cadastrar pessoa jurídica" ){
                Console.Clear();

                bool cnpjValido;
                do{
                    Console.WriteLine($"Digite o CNPJ Ex: 00.000.000/0000-00 ou 00000000000000");
                    string? cnpj = Console.ReadLine();

                    cnpjValido = metodoPj.ValidarCnpj(cnpj);
                    if(cnpjValido){
                        novaPj.cnpj = cnpj;
                    }else{
                        Console.WriteLine($"CNPJ digitado invalido, digite o CNPJ no formato Valido");
                    }
                } while (cnpjValido == false);

                Console.WriteLine($"Digite o nome do responsavel pela empresa que deseja cadastrar");
                novaPj.nome = Console.ReadLine();
                
                Console.WriteLine($"Digite a Razão Social");
                novaPj.razaoSocial = Console.ReadLine();

                Console.WriteLine($"Digite o rendimento mensal (Digite apenas numeros)");
                novaPj.rendimento = float.Parse(Console.ReadLine());
               
                Console.WriteLine($"Digite o logradouro (nome da rua, avenida, travessa e etc..)");
                novoEndPj.logradouro = Console.ReadLine();

                Console.WriteLine($"Digite o Numero");
                novoEndPj.numero = int.Parse(Console.ReadLine());

                Console.WriteLine($"Digite o CEP (apenas numeros)");
                novoEndPj.cep = int.Parse(Console.ReadLine());

            
                Console.WriteLine($"Este endereços é comercial? S/N");
                string endCom = Console.ReadLine().ToUpper();
                if(endCom == "S" ){
                    novoEndPj.endComercial = true;
                }else{
                    novoEndPj.endComercial = false; 
                }
        
                novaPj.endereco = novoEndPj;

                // listaPj.Add(novaPj);

                // using (StreamWriter sw = new StreamWriter($"teste/{novaPj.nome}.txt"))
                // {
                // sw.WriteLine($"CNPJ: {novaPj.cnpj}");
                // sw.WriteLine($"Nome: {novaPj.nome}");
                // sw.WriteLine($"Razão Social: {novaPj.razaoSocial}");
                // sw.WriteLine($"Endereço: {novaPj.endereco.logradouro}, {novaPj.endereco.numero}, {novaPj.endereco.cep}");
                // sw.WriteLine($"Rendimento: {novaPj.rendimento.ToString("C")}");
                // }
                metodoPj.inserir(novaPj);
                BarraCarregamento("Cadastro Realiado com Sucesso", 600);

            }else if( opcaoPj == "2" || opcaoPj == "Listar" || opcaoPj == "2 - Listar Pessoa Jurídica" || opcaoPj == "2 - listar pessoa juridica" || opcaoPj == "Listar Pessoa Jurídica" || opcaoPj == "listar pessoa jurídica" || opcaoPj == "Listar Pessoa Juridica"){
                Console.Clear();
                List<PessoaJuridica> listaPj = metodoPj.LerArquivo();
                
                foreach (PessoaJuridica itemPj in listaPj)
                {
                    Console.WriteLine(@$"
Nome: {itemPj.nome}
Razão Social: {itemPj.razaoSocial}
CNPJ: {itemPj.cnpj}
Endereço: {itemPj.endereco.logradouro}, {itemPj.endereco.numero}, {itemPj.endereco.cep}
Rendimento: {itemPj.rendimento.ToString("C")}
Taxa de imposto a ser pago é: {metodoPj.PagarImposto(itemPj.rendimento).ToString("C")}
");

                        Console.WriteLine($"Aperte 'ENTER' para retorna ao menu anterior");
                        Console.ReadLine();
    
                }

//                 if(listaPj.Count > 0){
//                     foreach(PessoaJuridica cadaPj in listaPj){
//                         Console.WriteLine(@$"
// CNPJ: {cadaPj.cnpj}
// Nome: {cadaPj.nome}
// Razão Social: {cadaPj.razaoSocial}
// Endereço: {cadaPj.endereco.logradouro}, {cadaPj.endereco.numero}, {cadaPj.endereco.cep}
// Redimento: {cadaPj.rendimento.ToString("C")}
// Taxa de imposto a ser pago é: {metodoPj.PagarImposto(cadaPj.rendimento).ToString("C")}
// ");

//                         Console.WriteLine($"Aperte 'ENTER' para retorna ao menu anterior");
//                         Console.ReadLine();
//                     }
//                 }else{
//                     Console.WriteLine($"Lista Vazia!");
//                     Thread.Sleep(3000);
                    
//                 }

                // Console.WriteLine($"Digite o nome da pessoa");
                // string arquivoPj = Console.ReadLine();
                // if(File.Exists($"teste\\{arquivoPj}.txt"))
                // {
                //     Console.Clear();
                //     using(var reader = new StreamReader($"teste\\{arquivoPj}.txt"))
                //     {
                //         string? linha;
                //         while((linha = reader.ReadLine()) != null)
                //         {
                //             Console.WriteLine($"{linha}");
                            
                //         }   
                //     }
                //     Console.WriteLine($"Aperte 'ENTER' para retorna ao menu anterior");
                //     Console.ReadLine();
                // }else{
                //     BarraCarregamento("Pessoa não encontrado", 1000);
                // }
            }else if(opcaoPj == "0" || opcaoPj == "voltar" || opcaoPj == "Voltar" || opcaoPj == "voltar ao menu anterior" || opcaoPj == "0 - voltar ao menu anterior" || opcaoPj == "Voltar ao menu anterior"){
                BarraCarregamento("Carregando", 1000);
            }else{
                Console.WriteLine($"Comando invalido, escolha uma opção valida!");
                Thread.Sleep(1000);
                Console.Clear();
            }
        } while (opcaoPj != "0");

        Console.WriteLine($"Aperte 'ENTER' para retorna ao menu anterior");
        Console.ReadLine();
    } else if (opcao == "0" || opcao == "Sair" || opcao == "sair" || opcao == "0 - Sair")
    {
        BarraCarregamento("Finalizando", 0);
    } else {
        Console.WriteLine($"Comando invalido, escolha uma opção valida!");
        Thread.Sleep(1000);
        Console.Clear();
    }
}while(opcao != "0");


static void BarraCarregamento(string text, int tempo){
    Console.Clear(); 
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(text);
    for (var i =0; i < 4; i++)
    {
        Console.Write(".");
        Thread.Sleep(tempo);
    }
    Console.ResetColor();
    Console.Clear();   
}