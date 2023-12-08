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
    loadEventsType();
  }, [tipoEvento, userData.userId]);

  async function loadEventsType() {
    // trazer todos os eventos
    setShowSpinner(true)
    try {
      if (tipoEvento === '1') {
        const promise = await api.get("/Evento")
        const promiseEvents = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`);
        const dadosMarcados = await verificaPresenca(promise.data, promiseEvents.data)

        console.clear();
        console.log(dadosMarcados);
        setEventos(dadosMarcados)
      }
      else if (tipoEvento === '2') {
        let arrEventos = [];
        const promise = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`);

        promise.data.forEach((e) => {
          arrEventos.push({ ...e.evento, situacao: e.situacao, idPresencaEvento: e.idPresencaEvento })
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
      setShowSpinner(false)
      return;
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

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {

      for (let i = 0; i < eventsUser.length; i++) {

        if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento
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

  async function loadMyComentary(idEvent) {
    // alert("é noix")
    try {
      const retorno = await api.get("/ComentarioEvento/BuscarPorIdUsuario", {
        idUsuario: userData.userId,
        idEvento: idEvent,
      })

      console.log(retorno);
    } catch (error) {
      
    }
  }

  async function postMyComentary(description, idEvent) {
    
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  async function handleConnect(idEvent, whatTheFunction /*connect */, idPresencaEvento = null) {
    setShowSpinner(true)
    if (whatTheFunction === 'conect' /* !connect*/) {
      try {
        const promise = await api.post('/PresencasEvento', {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent,
          idPresencaEveto: idPresencaEvento
        })

        if (promise.status === 201) {
          loadEventsType()

          setNotifyUser({
            titleNote: "Sucesso!",
            textNote: `Sua presenca foi confirmada, Bom evento!`,
            imgIcon: "success",
            imgAlt:
              "",
            showMessage: true,
          });
        }
        return;
      } catch (error) {
        setNotifyUser({
          titleNote: "Erro!",
          textNote: `Náo foi possivel Cadastrar, verifique sua internet!`,
          imgIcon: "danger",
          imgAlt:
            "",
          showMessage: true,
        });
      }
      setShowSpinner(false)
      return;
    }
    setShowSpinner(true)
    try {
      const promiseDelete = await api.delete(`/PresencasEvento/` + idPresencaEvento)

      if (promiseDelete.status === 204) {
        loadEventsType()

        setNotifyUser({
          titleNote: "Sucesso!",
          textNote: `Sua presenca foi desconfirmada, Bom descanso!`,
          imgIcon: "success",
          imgAlt:
            "",
          showMessage: true,
        });
      }
      return;
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro!",
        textNote: `Náo foi possivel deletar o cadastro, verifique sua internet!`,
        imgIcon: "danger",
        imgAlt:
          "",
        showMessage: true,
      });
    }
    setShowSpinner(false)
  }

  return (
    <>
      <MainContent>
        <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
        {showSpinner ? <Spinner /> : null}
        <Container>
          <Title titleText={"Eventos"} additionalClass="custom-title" />

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
          fnGet={loadMyComentary()}
          fnPost={postMyComentary}
        />
      ) : null}
    </>
  );
}

export default EventosAlunoPage;
