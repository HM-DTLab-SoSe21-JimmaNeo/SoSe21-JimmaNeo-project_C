# E-Neo

## 1 Press Release:

Vorstellung der neuen E-Learning Plattform „e-Neo“.
Die Kooperation der LMU und der Jimma University Specialized Hospital
hat die die neue webbasierte Lernumgebung zur Fortbildung von
medizinischem Personal im Bereich Neonatologie hervorgebracht.
Studenten der Hochschule München helfen bei der Entwicklung des
Programmes.
Die vorherrschende Corona-Pandemie macht es schwer praktisches Wissen
den Ärzten vor Ort in Jimma näher zu bringen, daher soll die E-Learning
Plattform "e-Neo“, von der LMU, eine Brücke, für das theoretische Lernen
und der ausgeübten Praxis bilden.
Sie soll den dortigen Mitarbeiter, welche am strukturierten
Fortbildungsprogramm teilnehmen, trotz der pandemischen
Einschränkungen, eine Möglichkeit bieten, flexibel neue Lerninhalte zu
erschließen und zu teilen. Dabei kann sich der User auf der Plattform
anmelden und dort Tests mit Multiple-Choice-Fragen durchführen. Alle
Kapitel sind modular und themenübergreifend strukturiert, sodass der User
niemals den roten Faden verliert.
Ein großes Augenmerk gilt auch der Community-Share Funktion, die es den
Ärzten ermöglicht, eigenes Wissen, in Form von Videos, Beiträgen oder
wissenschaftlichen Essays, zu verbreiten und sich untereinander zu
vernetzen, um so ein Upload Forum für die Neonatologie zu schaffen.
Die Interaktivität unter einander sowie ein anstoßender Lernprozess durch
„Learning by doing“ sind hier groß geschrieben und von besonderer
Bedeutung für die E-Learning Plattform „e-Neo“.
" Es ist so als würden wir Sie persönlich Vorort unterrichten und die große
Entfernung keine Rolle mehr spielen würde." (Tobias B., LMU)
„ Die Community-Share Funktion bietet den Ärzten die Möglichkeit
persönliches und direktes Feedback zu dem Erlernten zu bekommen.
Hier kann der Fokus auf ein beliebiges Thema gelegt werden und je nach
Verlangen ein Erklärungsvideo gedreht oder ein Essay verfasst werden.
Toller und kreativer Gedanke !“
Das voraussichtliche Erscheinungsdatum ist für den 25.06.2021 angesetzt.

## 2 Anwendungsbeschreibung:

- Quiz:

- Forum:

- Login

## 3 SoftwareArchitektur:

Die Softwarearchitecktur unserer eNeo Anwendung lässt sich grob in die drei Teile, 
Client (WebApp, Frontend), Server (Backend) & Shared unterteilen:

Frontend, WebApp
Das Frontend dient zur grafischen Darstellung und dient als Benutzerschnittstelle. 
Oft wird es auch als Presentaionsschichtschicht bezeichnet. 

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


- Uml:

## 4 Ansprechpartner:

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

Backend:
-> (Leon und Kevin)





## 5 Anlagen:

- [Dokumentation](https://gitlab.lrz.de/seii_sose_2021/project_c/-/tree/master/Dokumentation)


- [FAQ](https://gitlab.lrz.de/seii_sose_2021/project_c/-/blob/master/Dokumentation/LMU_TEAM_C_FAQ.pdf)


- [Storyboard](https://gitlab.lrz.de/seii_sose_2021/project_c/-/blob/master/Dokumentation/Storyboard.jpeg)


- [PressRelease](https://gitlab.lrz.de/seii_sose_2021/project_c/-/blob/master/Dokumentation/LMU_TEAM_C_PR.pdf)
