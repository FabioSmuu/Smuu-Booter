# Smuu Booter

Esta aplicação consiste em explorar uma falha ddos em servições como hospedagens e vpn's.

> **Aviso**: estes recursos foram removidos por questões de segurança, pois este projeto se trata de um estudo e não uma ferramenta para ataque, então suas ações sob qualquer uso da ferramente, não dirija-se a min.

 Antes de rodar o projeto de uma olhada no meu repositorio [ArquivoINI](https://github.com/FabioSmuu/ArquivoINI).

### Recursos removido por questões de segurança/ética:
- Bypass(Efetividade) em WAF.
- Spoofing em rede semelhante a OVH.
- Hammer em conexão com apache 1.X a 2.X/IIS

Este projeto não possui limitação de thread e pode ser executado de forma multua.

### Mas a final, oque é este tal Booter?
Pois bem, um booter é uma aplicação para ataque de "negação de serviço" usando uma lista de proxy.

Estas proxys são responsáveis por passar uma certificação SSL falsa e inserir cookies em um alvo específico.

Cada booter executado Usará uma proxy aleatória da lista para o spoofing do certificado SSL.

Limitei uma proxi por terminal, mas mantive a confirmação das threads.

Fique de olho nos statuscode: forbidden, bad request, not found dentre outros...

| Dependencias |Versão|
|-|-|
| Jint | 2.11.58 |
| System.IO | 4.3.0 |
| System.Runtime | 4.3.1 |
| System.Net.Http | 4.3.4 |
| System.Security.Cryptography.Encoding | 4.3.0 |
| System.Security.Cryptography.Algorithms | 4.3.1 |
| System.Security.Cryptography.Primitives | 4.3.0 |
| System.Security.Cryptography.X509Certificates | 4.3.2 |

**Obrigado pela sua atenção!**
