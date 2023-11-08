import React from "react";
import "./HomePage.css";
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "../../components/ContactSection/ContactSection";
import NextEvent from "../../components/NextEvent/NextEvent";
import Container from "../../components/Container/Container";

const HomePage = () => {
  return (
    <MainContent>
      <Banner />

      <section className="proximos-eventos">
        <Container>

          <Title titleText="Próximos Eventos" additionalClass="margem-acima" />
          <div className="events-box">
            <NextEvent
              title={"Happy Hour Event"}
              description={"Evento legal :)"}
              eventDate={"14/11/23"}
              idEvento={"fih75984oijr3uh78245hnb03875j"}
            />

            <NextEvent
              title={"Prova seletiva"}
              description={"Prova de seleção dos alunos"}
              eventDate={"26/11/23"}
              idEvento={"iur3ieu587ty83reywhieunwicnbu"}
            />

            <NextEvent
              title={"Palestra"}
              description={"Palestra para a motivação de todos"}
              eventDate={"12/12/23"}
              idEvento={"83tr78yb3rn87gvyhu8n28rgfbu3i"}
            />

            <NextEvent
              title={"Fim do ano"}
              description={"Ultimo dia de aula"}
              eventDate={"19/12/23"}
              idEvento={"ehbr876tyrf98cuhj3aeb2r8gi3y4"}
            />
          </div>
        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
