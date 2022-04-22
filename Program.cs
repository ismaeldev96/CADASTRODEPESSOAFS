using CADASTRODEPESSOAFS.Classes;
Console.Clear();

Console.WriteLine(@$"
*********************************************
***   Bem Vindo ao sistema de cadastro!   ***
*********************************************
");
Thread.Sleep(1000);

BarraCarregamento("Carregando", 500);

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

        PessoaFisica novaPf = new PessoaFisica();
        PessoaFisica metodoPf = new PessoaFisica();
        Endereco novoEnd = new Endereco();


        novaPf.nome = "ismael";
        novaPf.cpf = "06376564585";
        novaPf.rendimento = 1000.5f;
        var thTH = new System.Globalization.CultureInfo("th-TH");
        var cal = thTH.DateTimeFormat.Calendar;
        novaPf.dataNasc = new DateTime(1996, 04, 05, cal);


        novoEnd.logradouro = "Rua K";
        novoEnd.numero = 291;
        novoEnd.cep = 49043236;
        novoEnd.endComercial = false;

        novaPf.endereco = novoEnd;

        Console.WriteLine(@$"
Nome: {novaPf.nome}
CPF: {novaPf.cpf}
Data de Nascimento: {novaPf.dataNasc:d} maior de idade: {(metodoPf.ValidarDataNascimento(novaPf.dataNasc)? "sim" : "Não")}
Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}, {novaPf.endereco.cep}
Redimento: {novaPf.rendimento.ToString("C")}
Taxa de imposto a ser pago é: 
");

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
        //novaPj.cnpj = "00.000.000/0001-14";
        novaPj.cnpj = "00.000.000/0001-1";
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
Taxa de imposto a ser pago é: 
");

        Console.WriteLine($"Aperte 'ENTER' para retorna ao menu anterior");
        Console.ReadLine();
    } else if (opcao == "0" || opcao == "Sair" || opcao == "sair" || opcao == "0 - Sair")
    {
        BarraCarregamento("Finalizando", 300);
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