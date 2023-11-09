import React, { useEffect, useState } from "react";
import "./HomePage.css";
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "../../components/ContactSection/ContactSection";
import NextEvent from "../../components/NextEvent/NextEvent";
import Container from "../../components/Container/Container";
import axios from "axios";

const HomePage = () => {

  useEffect(() => {
    // chamar a api
    async function getNextEvets() {
      try {
        const promise = await axios.get(endereco)

        console.log(promise.data);
        setNextEvents(promise.data)
      } catch (error) {
        alert("deu ruim aq")
      }
    }
  }, [])

  //Fake mock - api mocada
  const [nextEvents, setNextEvents] = useState([]);

  return (
    <MainContent>
      <Banner />

      <section className="proximos-eventos">
        <Container>
          <Title titleText="Próximos Eventos" additionalClass="margem-acima" />
          <div className="events-box">
            {nextEvents.map((e) => {
              return (
                <NextEvent
                  title={e.title}
                  description={e.description}
                  eventDate={e.data}
                  idEvento={e.id}
                />
              );
            })}
          </div>
        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
