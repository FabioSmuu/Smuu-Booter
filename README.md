# Repositorio de Sistema Booter

[![N|Solid](https://i.imgur.com/mF9AKO0.png)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=fabinhoec2210@gmail.com&item_name=F%C3%A1bio&currency_code=BRL)

Este sistema consiste em explorar uma falha ddos em hospedagens e vps.

Aviso: estes recursos foram removidos por questões de segurança, pois este projeto se trata de um estudo e não um ataque, então suas ações sob qualquer uso da ferramente, não dirija-se a min.

 Antes de rodar o projeto de uma olhada no meu repositorio [ArquivoINI](../FabioSmuu/ArquivoINI), pois sem este arquivo não terá como configura-lo.

### Recursos removido por questões de segurança:
- Efetividade contra CloudFlare.
- Spoofing na rede OVH
- Hammer em conexão com apache 1.X a 2.X/IIS
- Limitação de threads

### Mas afinal, oque é este tal Booter?
Pois bem, um booter é um ataque de "negação de serviço" usando uma lista com diversas proxys contidas nelas.

Estas proxys são responsaeis por passar a uma certificação SSL falsa e inserindo cookies direto ao acesso do alvo (em termos leigos).

Cada booter executado tem como função rodar uma proxy e um certificado para que enfim seja enviada uma contia fixa de threads efetuando uma sobrecarga an conexão, resultando em um statuscode de forbidden, bad request, not found dentre outros...

**Obrigado pela sua atenção!**
