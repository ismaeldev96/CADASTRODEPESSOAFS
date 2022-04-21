using CADASTRODEPESSOAFS.Classes;

// PessoaFisica novaPf = new PessoaFisica();
// PessoaFisica metodoPf = new PessoaFisica();
// Endereco novoEnd = new Endereco();


// novaPf.nome = "ismael";
// novaPf.cpf = "06376564585";
// novaPf.rendimento = 1000.5f;
// var thTH = new System.Globalization.CultureInfo("th-TH");
// var cal = thTH.DateTimeFormat.Calendar;
// novaPf.dataNasc = new DateTime(1996, 04, 05, cal);


// novoEnd.logradouro = "Rua K";
// novoEnd.numero = 291;
// novoEnd.cep = 49043236;
// novoEnd.endComercial = false;

// novaPf.endereco = novoEnd;

// Console.WriteLine(@$"
// Nome: {novaPf.nome}
// CPF: {novaPf.cpf}
// Data de Nascimento: {novaPf.dataNasc:d} maior de idade: {(metodoPf.ValidarDataNascimento(novaPf.dataNasc)? "sim" : "Não")}
// Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}, {novaPf.endereco.cep}
// Redimento: {novaPf.rendimento.ToString("C")}
// Taxa de imposto a ser pago é: 
// ");

PessoaJuridica metodoPj = new PessoaJuridica();
PessoaJuridica novaPj = new PessoaJuridica();
Endereco endPj = new Endereco();

novaPj.nome = "Ismael";
novaPj.razaoSocial = "Mercado das Repesentações";
novaPj.cnpj = "00.000.000/0001-14";
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
