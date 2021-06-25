# E-Neo
Das Ziel von "E-Neo" ist es,dem medizinischen Personal in Äthiopien verschiedene Online Sesssions anzubieten, mithilfe einer Web Anwendung. Wichtig hier zu erwähnen, die Web Anwendung soll besonders benutzerfreundlich und klar auf den User zugeschnitten sein. Zusätzlich soll der Spaß Faktor nicht verloren gehen bei der Bedienung, hier zu kommt unser Feature, das Upload Forum zu Gute.

Als Team möchten wir zuerst dem Herr Prof. Kofler ein grosses Dank aussprechen, welcher nicht nur uns das Vertrauen gegeben hat solch eine Art an Projekt durchführen zu können sondern auch rund um die Uhr zur Seite stand. Des Weiteren bedanken wir uns natürlich an die Auftraggeber Victoria Lieftüchter und Dr. Tobias Reicherzer für die Möglichkeit am Projekt teilnehemen zu können. Zuletzt auch ein Dank an Lars Schmitz, für dessen Anwesenheit und Mitwirken von AWS.

## 1 Press Release:

- [Press Release](https://gitlab.lrz.de/seii_sose_2021/project_c/-/blob/master/Dokumentation/LMU_TEAM_C_PR.pdf)

## 2 Anwendungsbeschreibung:

- [Login Vorgang](Dokumentation/Login_Ablauf.pdf)

- [Forum](Dokumentation/Forum_AblaufNeu.pdf)

- [Quiz](Dokumentation/Quiz_Ablauf.pdf)

## 3 SoftwareArchitektur:

Die Softwarearchitecktur unserer "e-Neo" Anwendung lässt sich grob in die drei Teile, 
Client (WebApp, Frontend), Server (Backend) & Shared unterteilen:

Frontend, WebApp
Das Frontend dient zur grafischen Darstellung und dient als Benutzerschnittstelle. 
Oft wird es auch als Präsentationsschicht bezeichnet. 

- Pages: Benutzerschnittstelle bestehend aus HTML, CSS, Razor- & C#-Blazor Code 
         (z. B. ForumMainPage.razor, Post.razor)
- Komponenten: wiederverwendbare Bestandteile, die dann auf mehreren Pages ein-
               gestzt werden können - Vermeidung von Redundanz!
- Services: Senden bzw. Empfangen der HTTP-Requests - Verbindung von Front- 
            & Backend (async, await Methoden, Fetch-Data, vgl. Javascript bzw. React)


Backend, Server
Das Backend stellt die eigentliche Logik bzw. Verarbeitung der Daten, 
Verwaltung der Datenbank dar.

- Controller: Stellt die Rest-Schnittstellen zur Verfügung (GET, PUT, POST, DELETE) 
              (z. B. api/Definition, api/VideoDefinition)
- Services: Anwendungslogik & Datenbankzugriff 
            -> CRUD-Befehle zum Anlegen, Lesen, Aktualisieren & Löschen
- Domains: Umfasst die Datenmodelle (vgl. UML-Datenmodell, Anhang)
           (CodeFirst: Enity-Framework Annotations [Key], [Required], etc.,
            damit die Properties als Table in der Datenbank angelegt werden)
- Data Access / DataBaseContext: Verwaltet den Zugriff auf die Datenbank


Shared
Im Shared-Ordner befinden sich die DTO'S (Data Transfer Objekte), welche zum Austausch von 
Front- zu Backend verwendet werden. 
In der Startup.cs werden diese durch einen Automapper dann in die Domains gemappt.


- [Architektur](Dokumentation/architecktur.pdf)

## 4 Team und Ansprechpartner:

Das Team "e-Neo"(Gruppe C) besteht aus sieben Teammitgliedern:

Sahin, Emre |
Gahlmann, Constantin |
Ha, Kevin |
Forster, Leon |
Bronold, Daniel |
Bublitz, Alina |
Themann, Stefan |

Ansprechpartner: emre.sahin@hm.edu

Frontend:
-> UploadForum (Emre und Constantin)
-> Quiz (Alina und Stefan)
-> Login (Daniel)
-> UI (Kevin und Emre)

Backend:
-> (Leon und Kevin)





## 5 Anlagen:

- [Dokumentation](https://gitlab.lrz.de/seii_sose_2021/project_c/-/tree/master/Dokumentation)


- [FAQ](https://gitlab.lrz.de/seii_sose_2021/project_c/-/blob/master/Dokumentation/LMU_TEAM_C_FAQ.pdf)


- [Storyboard](https://gitlab.lrz.de/seii_sose_2021/project_c/-/blob/master/Dokumentation/Storyboard.jpeg)


- [PressRelease](https://gitlab.lrz.de/seii_sose_2021/project_c/-/blob/master/Dokumentation/LMU_TEAM_C_PR.pdf)
