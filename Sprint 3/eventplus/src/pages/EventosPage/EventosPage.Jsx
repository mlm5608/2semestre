import React, { useEffect, useState } from 'react';
import './EventosPage.css'
import Title from '../../components/Title/Title';
import MainContent from '../../components/MainContent/MainContent';
import Container from '../../components/Container/Container'
import ImageIllustartor from '../../components/ImageIllustartor/ImageIllustartor';
import eventImage from '../../assets/images/evento.svg'
import { Button, Input, Select } from '../../components/FormComponents/FormComponents';
import api from '../../Services/Service'
import TableEv from './TableEv/TableEv';
import Notification from '../../components/Notification/Notification';
import Spinner from '../../components/Spinner/Spinner';

//*************************************************************************************
const EventosPage = () => {

    const [frmEdit, setFrmEdit] = useState(false)
    const [eventos, setEventos] = useState([])//array
    const [notifyUser, setNotifyUser] = useState({})
    const [name, setName] = useState("")
    const [description, setDescription] = useState("")
    const [eventType, setEventType] = useState("")//função cadastrar (objeto)
    const [date, setDate] = useState("")
    const [instituicao, setInstituicao] = useState("")
    const [tiposDeEventos, setTiposDeEventos] = useState([])//Para gerar o select (array)
    const [idEvento, setIdEvento] = useState("")

    useEffect(() => {
        async function getEvents() {
            try {
                const promise = await api.get("/Evento")
                const inst = await api.get("/Instituicao")
                const retorno = await api.get("/TiposEvento")

                const dadosApi = retorno.data
                const arrayMod = []

                dadosApi.forEach(e => {
                    arrayMod.push({
                        value: e.idTipoEvento,
                        text: e.titulo
                    })
                });

                setTiposDeEventos(arrayMod)
                setEventos(promise.data)
                setInstituicao(inst.data[0].idInstituicao)

            } catch (error) {
                console.log(error);
                setNotifyUser({
                    titleNote: "Erro!",
                    textNote: `Ocorreu algo de errado, verifique sua conexão internet!`,
                    imgIcon: "danger",
                    imgAlt:
                        "",
                    showMessage: true,
                });
            }
        }
        getEvents()
    }, [])
    async function showUpdateForm(idEvent) {
        setFrmEdit(true);
        try {
            const retorno = await api.get(`/Evento/${idEvent}`)
            setName(retorno.data.nomeEvento)
            setDescription(retorno.data.descricao)
            setEventType(retorno.data.idTipoEvento)
            setDate(retorno.data.dataEvento)
            setIdEvento(idEvent)
        } catch (error) {
            console.log("deu ruim aqui");
            console.log(error);
        }
    }
    async function handleDelete(id) {
        try {
            await api.delete(`/Evento/${id}`)
            const retornoGet = await api.get('/Evento')
            setEventos(retornoGet.data)
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: `Ocorreu algo de errado ao deletar, verifique sua conexão internet!`,
                imgIcon: "warning",
                imgAlt:
                    "",
                showMessage: true,
            });
        }

        setNotifyUser({
            titleNote: "Sucesso",
            textNote: `Deletado com sucesso!`,
            imgIcon: "success",
            imgAlt:
                "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
            showMessage: true,
        });
    }
    function handleUpdate() {

    }
    async function handleSubmit(e) {
        e.preventDefault();

        if (name.trim().length < 3) {
            alert("O título precisa ter mais de 3 letras!")
        }

        try {
            const retorno = await api.post("/Evento", { nomeEvento: name, descricao: description, idTipoEvento: eventType, dataEvento: date, idInstituicao: instituicao })

        } catch (error) {
            console.log(error);
        }
    }
    function editActionAbort() {

    }



    //*************************************************************************************
    return (
        <MainContent>
            <Notification {...notifyUser} setNotifyUser={setNotifyUser} />

            <section className='cadastro-evento-section'>
                <Container>
                    <div className='cadastro-evento__box'>
                        <Title titleText={"Página de Eventos"} />
                        <ImageIllustartor
                            imageRender={eventImage}
                            alterText={""}
                        />

                        <form onSubmit={frmEdit ? handleUpdate : handleSubmit} className="ftipo-evento">
                            {!frmEdit ?
                                (<>
                                    {/* Input 1 ************************ */}
                                    <Input
                                        type={"text"}
                                        id={"Nome Evento"}
                                        name={"Nome Evento"}
                                        placeholder={"Nome do Evento"}
                                        required={"required"}
                                        value={name}
                                        manipulationFunction={
                                            (e) => {
                                                setName(e.target.value)
                                            }
                                        }
                                    />

                                    {/* Input 2 ************************ */}
                                    <Input
                                        type={"text"}
                                        id={"Descricao"}
                                        name={"Descricao"}
                                        placeholder={"Descrição"}
                                        required={"required"}
                                        value={description}
                                        manipulationFunction={
                                            (e) => {
                                                setDescription(e.target.value)
                                            }
                                        }
                                    />
                                    {/* Input 3 ************************ */}

                                    <Select
                                        options={tiposDeEventos}
                                        id={"TipoEvento"}
                                        name={"TipoEvento"}
                                        required={"required"}
                                        manipulationFunction={(p) => {
                                            setEventType(p.target.value)
                                        }}
                                    />

                                    {/* Input 4 ************************ */}
                                    <Input
                                        type={"date"}
                                        id={"Data"}
                                        name={"Data"}
                                        placeholder={"Data do Evento"}
                                        required={"required"}
                                        value={date}
                                        manipulationFunction={
                                            (e) => {
                                                setDate(e.target.value)
                                            }
                                        }
                                    />

                                    <Button
                                        text={"Cadastrar"}
                                        type={"submit"}
                                        id={"Button"}
                                        name={"Button"}
                                    />
                                </>)
                                :
                                (<>
                                    {/* Input 1 ************************ */}
                                    <Input
                                        type={"text"}
                                        id={"Nome Evento"}
                                        name={"Nome Evento"}
                                        placeholder={"Nome do Evento"}
                                        required={"required"}
                                        value={name}
                                        manipulationFunction={
                                            (e) => {
                                                setName(e.target.value)
                                            }
                                        }
                                    />
                                    {/* Input 2 ************************ */}
                                    <Input
                                        type={"text"}
                                        id={"Descricao"}
                                        name={"Descricao"}
                                        placeholder={"Descrição"}
                                        required={"required"}
                                        value={description}
                                        manipulationFunction={
                                            (e) => {
                                                setDescription(e.target.value)
                                            }
                                        }
                                    />
                                    {/* Input 3 ************************ */}

                                    <Select
                                        options={tiposDeEventos}
                                        id={"TipoEvento"}
                                        name={"TipoEvento"}
                                        required={"required"}
                                        manipulationFunction={(p) => {
                                            setEventType(p.target.value)
                                        }}
                                        defaultValue=""
                                    />

                                    {/* Input 4 ************************ */}
                                    <Input
                                        type={"date"}
                                        id={"Data"}
                                        name={"Data"}
                                        placeholder={"Data do Evento"}
                                        required={"required"}
                                        value={date}
                                        manipulationFunction={
                                            (e) => {
                                                setDate(e.target.value)
                                            }
                                        }
                                    />

                                    <div className='buttons-editbox'>
                                        <Button
                                            text={"Atualizar"}
                                            type={"submit"}
                                            id={"Button-Update"}
                                            name={"Button-Update"}
                                            additionalclass={"button-component--middle"}
                                        />

                                        <Button
                                            text={"Cancelar"}
                                            type={"cancel"}
                                            id={"Cancel-Button"}
                                            name={"Cancel-Button"}
                                            additionalclass={"button-component--middle"}
                                            manipulationFunction={() => { editActionAbort() }}
                                        />
                                    </div>
                                </>)
                            }
                        </form>
                    </div>
                </Container>
            </section>

            <section className='lista-eventos-section'>
                <Container>
                    <Title titleText={"Lista de Eventos"} color="white" />

                    <TableEv
                        dados={eventos}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />
                </Container>
            </section>
        </MainContent>
    );
};

export default EventosPage;