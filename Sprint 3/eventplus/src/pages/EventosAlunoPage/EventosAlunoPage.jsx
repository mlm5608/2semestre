import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from ".//TableEvA/TableEvA";
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Notification from '../../Components/Notification/Notification';
import Modal from "../../Components/Modal/Modal";
import api from "../../Services/Service";

import "./EventosAlunoPage.css";
import { UserContext } from '../../context/AuthContext'

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);

  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: 1, text: "Todos os eventos" },
    { value: 2, text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const [notifyUser, setNotifyUser] = useState({})

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  useEffect(() => {
    async function loadEventsType() {
      // trazer todos os eventos
      setShowSpinner(true)
      try {
        if (tipoEvento === '1') {
          const promise = await api.get("/Evento")
          const promiseEvents = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`);
          const dadosMarcados =  verificaPresenca(promise.data, promiseEvents.data)

          setEventos(dadosMarcados)
        }
        else if (tipoEvento === '2') {
          let arrEventos= [];
          const promise = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`);

          promise.data.forEach((e) => {
              arrEventos.push({...e.evento, situacao : e.situacao})
          });

          console.log(promise.data);
          setEventos(arrEventos)
        }
        else {
          setEventos([])
          setNotifyUser({
            titleNote: "Erro!",
            textNote: `Selecione uma opção válida`,
            imgIcon: "warning",
            imgAlt:
              "",
            showMessage: true,
          });
        };
      } catch (error) {
        setNotifyUser({
          titleNote: "Erro!",
          textNote: `Ocorreu algo de errado, verifique sua internet!`,
          imgIcon: "danger",
          imgAlt:
            "",
          showMessage: true,
        });
      }

      setShowSpinner(false)
    }
    loadEventsType();
  }, [tipoEvento, userData.userId]);

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {

      for (let i = 0; i < eventsUser.length; i++) {

        if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
          arrAllEvents[x].situacao = true;

          break;
        }
      }
    }
    return arrAllEvents;
  }

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
  }
  return (
    <>
      <MainContent>
        <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
        {showSpinner ? <Spinner /> : null}
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
