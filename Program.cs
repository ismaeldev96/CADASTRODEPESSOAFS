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
        BarraCarregamento("Carregando", 600);
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
            if (opcaoPf == "1" || opcaoPf == "Cadastar" || opcaoPf == "1 - Cadastar Pessoa Fisica" || opcaoPf == "cadastar pessoa fisica" || opcaoPf == "cadastar pessoa física" || opcaoPf == "Cadastar Pessoa Física")
            {
                PessoaFisica novaPf = new PessoaFisica();
                PessoaFisica metodoPf = new PessoaFisica();
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
                if(endCom == "S" || endCom == "s" || endCom == "sim" || endCom == "Sim"  || endCom == "SIM"){
                    novoEnd.endComercial = true;
                }else{
                    novoEnd.endComercial = false;
                    Console.WriteLine($"Opção invalida, digite 'S' para SIM e 'N' para Não");
                }
        
                novaPf.endereco = novoEnd;

                listaPf.Add(novaPf);
                BarraCarregamento("Cadastro Realiado com Sucesso", 3000);
                
            }else if(opcaoPf == "2" || opcaoPf == "Listar" || opcaoPf == "2 - Listar Pessoas Fisicas" || opcaoPf == "listar pessoas fisicas" || opcaoPf == "listar pessoa física" || opcaoPf == "Listar Pessoas Físicas"){

            }else if(opcaoPf == "0" || opcaoPf == "Voltar" || opcaoPf == "0 - Voltar ao menu anterior" || opcaoPf == "Voltar ao menu anterior" || opcaoPf == "voltar ao menu anterior"){
                BarraCarregamento("Carregando", 2000);
            } else {
                Console.WriteLine($"Comando invalido, escolha uma opção valida!");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }while(opcaoPf != "0");

        
        

//         Console.WriteLine(@$"
// Nome: {novaPf.nome}
// CPF: {novaPf.cpf}
// Data de Nascimento: {novaPf.dataNasc:d} maior de idade: {(metodoPf.ValidarDataNascimento(novaPf.dataNasc)? "sim" : "Não")}
// Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}, {novaPf.endereco.cep}
// Redimento: {novaPf.rendimento.ToString("C")}
// Taxa de imposto a ser pago é: {metodoPf.PagarImposto(novaPf.rendimento).ToString("C")}
// ");

        Console.WriteLine($"Aperte 'ENTER' para retorna ao menu anterior");
        Console.ReadLine();

    } else if (opcao == "2" || opcao == "2 - Pessoa Juridica" || opcao == "Pessoa Juridica" || opcao == "pessoa juridica")
    {
        BarraCarregamento("Carregando", 600);
        PessoaJuridica metodoPj = new PessoaJuridica();
        PessoaJuridica novaPj = new PessoaJuridica();
        Endereco endPj = new Endereco();

        novaPj.nome = "Ismael";
        novaPj.razaoSocial = "Mercado das Repesentações";
        novaPj.cnpj = "00.000.000/0001-14";
        // novaPj.cnpj = "00.000.000/0001-1";
        novaPj.rendimento = 100000.05f;

        endPj.logradouro = "Av. jose carlos";
        endPj.numero = 540;
        endPj.cep = 49043236;
        endPj.endComercial = true;

        novaPj.endereco = endPj;

        Console.WriteLine(@$"
Nome: {novaPj.nome}
Razão Social: {novaPj.razaoSocial}
CNPJ: {(metodoPj.ValidarCnpj(novaPj.cnpj)? novaPj.cnpj : "Ínvalido")}
Endereço: {novaPj.endereco.logradouro}, {novaPj.endereco.numero}, {novaPj.endereco.cep}
Redimento: {novaPj.rendimento.ToString("C")}
Taxa de imposto a ser pago é: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C")}
");

        Console.WriteLine($"Aperte 'ENTER' para retorna ao menu anterior");
        Console.ReadLine();
    } else if (opcao == "0" || opcao == "Sair" || opcao == "sair" || opcao == "0 - Sair")
    {
        BarraCarregamento("Finalizando", 0);
    } else {
        Console.WriteLine($"Comando invalido, escolha uma opção valida!");
        Thread.Sleep(3000);
        Console.Clear();
    }
}while(opcao != "0");


static void BarraCarregamento(string text, int tempo){
    Console.Clear(); 
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(text);
    for (var i =0; i < 8; i++)
    {
        Console.Write(".");
        Thread.Sleep(tempo);
    }
    Console.ResetColor();
    Console.Clear();   
}