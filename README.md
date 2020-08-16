# Login credentials

### Mobile

 #
      
         * Username: pacijent
         * Password: testtest
      
         * Username: pacijent2
         * Password: testtest

         * Username: pacijent3
         * Password: testtest

         * Username: pacijent4
         * Password: testtest

         * Username: pacijent5
         * Password: testtest

         * Username: pacijent6
         * Password: testtest

         * Username: pacijent7
         * Password: testtest

         * Username: pacijent8
         * Password: testtest

         * Username: pacijent9
         * Password: testtest

         * Username: pacijent10
         * Password: testtest

         * Username: pacijent11
         * Password: testtest

### Desktop

 #

         * Username: doktor
         * Password: testtest

         * Username: doktor2
         * Password: testtest

         * Username: medicinskitehnicar
         * Password: testtest
  
         * Username: radnikprijem
         * Password: testtest

         * Username: admin
         * Password: testtest
   

# MOBILE

  - Za registraciju pacijenta na mobilnoj aplikaciji, potrebno je potvrditi validnost ličnih podataka
    tako što će se unijeti broj zdravstvene knjižice, JMBG, ime i prezime. Ukoliko se podaci poklapaju
    sa podacima iz baze podataka, korisnički nalog će se kreirati.
    Planirano je da će zdravstvena ustanova već imati podatke pacijenata.

  - Lični podaci pacijenata koji se mogu koristiti pri registraciji (nisu registrovani):
      
    1)
      
         * BrojZdravstveneKnjizice: 12
         * JMBG: 1234567891
         * Ime: Fahir
         * Prezime: Pacdvadeset

      2)
      
         * BrojZdravstveneKnjizice: 13
         * JMBG: 9874563211
         * Ime: Fahir
         * Prezime: Pacdvajedan


# DESKTOP and recommendation system

 - **STEPS**
     1) Logovati se na mobilnu aplikaciju koristeci username naveden ispod i password "testtest"
     2) Na prvom tabu kliknuti na Zakazi pregled i kreirati zahtev za pregled odabirom doktora "Fahir Dokt"
     3) Logovati se na desktop aplikaciju koristeci kredencijale:
           * Username: doktor
           * Passowrd: testtest
     4) Nakon uspesnog logovanja kliknuti na button "Zahtevi za pregled" i pronaci kreirani zahtev
     5) Duplim klikom na red zahteva otvorice se dialog sa prikazom informacija o zahtevu
     6) Klikom na "Zakazi" otvorice se novi dialog za zakazivanje pregleda
     7) U dijelu "Vrijeme pregleda" ce biti vidljivi rezultati recommendation sistema

 - Preporuceno vrijeme koje bi sistem preporuke trebao vratiti bazirano na godistu rodjena pacijenta:
#
     FORMAT => PacijentUsername : PreporucenoVrijeme : GodinaRodjenjaPacijenta

     * pacijent : 10:00AM : 1993
     * pacijent2 : 12:00AM : 1993
     * pacijent3: 12:00AM : 1993
     * pacijent4: 12:00PM : 1993
     * pacijent5: 14:00PM : 1979
     * pacijent6: 14:00PM : 1979
     * pacijent7: 14:00PM : 1979
     * pacijent8: 15:00PM : 1956
     * pacijent9: 15:00PM : 1956
     * pacijent10: 15:00PM : 1956



# DESKTOP - Azure cognitive services - Face API

 - U sklopu administratorskog panela na desktop aplikaciji, postoji tab "Security"
   na kojem je će se moći pregledati trenutno aktivni korisnici u sklopu "Healthcare020 Pacijenti"
   person grupe  Face API eksternog servisa.

 - Za svakog pacijenta se pri kreiranju korisnickog naloga kreira i Person objekat koji će mu biti
   dodijeljen i koji će čuvati Face od tog pacijenta. Pri zameni profilne slike, ažurira se i Person
   objekat i dodaje novi Face.

 - Za postojeće pacijente (testne korisničke naloge), potrebno je dodati profilnu sliku nakon logiranja na mobilnu aplikaciju,
   na tab-u "Settings", kako bi se pomoću tog korisničkog naloga mogla izvšiti Face ID autentifikacija korisnika.

 - Na Login stranici, na mobilnoj aplikaciji, postoji mogućnost logiranja koristeći Face ID.
   U svrhu testiranja, ova funkcionalnost pruža mogućnost upload-a slike (selfie)
   iz galerije telefona. Planirani način FaceID autentifikacije je upload trenutno kreirane slike,
   tako što će korisnik proslijediti trenutni selfie, a ne sliku iz galerije.


# MOBILE <-> DESKTOP - Zahtev za posetu

- Na mobilnoj aplikaciji, postoji opcija za kreiranje zahteva za posetu, za neautentificirane
  korisnike tj. potencijalne posetioce. Posetioc unosi ime i prezime pacijenta na lečenju i bira
  neke od ponudjenih.
  U svrhu testiranja, pri pretraživanju pacijenta na lečenju može se unijeti ime "Fahir" i dobiće se dva testna pacijnenta na liječenju.

- Posetioc, nakon odabira pacijenta na lečenju, unosi broj telefona sa prefixom (+387,+381 ..) ili bez (bez = +387).
  Broj telefona služi za obaveštenje koje će posetioc dobiti putem SMS poruke, kada zahtev bude obrađen.

- Na desktop aplikaciji, logirajući se kao radnik na prijemu, koristeći kredencijale:

           * Username: radnikprijem
           * Password: testtest

  radnici će biti u mogućnosti da klikom na button "Automatski rasporedi posete", pozovu sistem automatskog rasporedjivanja zahteva za posete.
  Sistem je implementiran tako da rasporedjuje posete u dva dnevna termina i to za svakog pacijenta po maksimalno 2 posetioca u jednom terminu.
  Pri rasporedjivanju poseta, sistem obaveštava posetioce o odobrenom terminu posete, putem SMS poruke.

- Slanje SMS poruke za testno okruženje, koristeći Nexmo API, rade samo za verifikovane brojeve telefona. Tako da funkcionalnost verovatno neće raditi.
  (Možete mi se javiti da verifikujem vaš broj telefona, da bi isprobali funckionalnost)


# DESKTOP - Doktori i medicinski tehničari

 - Na desktop aplikaciji, pored administratora i radnika na prijemu, mogu se logovati i doktori i medicinski tehničari.

 - Kredencijali za testne korisnički naloge doktora su:

       1)
           * Username: doktor
           * Password: testtest
       2)
           * Username: doktor2
           * Password: testtest

 - Kredencijali za testni korisnički nalog medicinskog tehničara su:

       1)
           * Username: medicinskitehnicar
           * Password: testtest
