import React, { useEffect, useState } from 'react';
import './EventosPage.css'
import Title from '../../Components/Title/Title';
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container'
import ImageIllustartor from '../../Components/ImageIllustrator/ImageIllustrator';
import eventImage from '../../assets/images/evento.svg'
import { Button, Input, Select } from '../../Components/FormComponents/FormComponents';
import api from '../../Services/Service'
import TableEv from './TableEv/TableEv';
import { viewToDateFormatDb } from '../../Utils/stringFunction';
import Notification from '../../Components/Notification/Notification';
import Spinner from '../../Components/Spinner/Spinner';

//*************************************************************************************
const EventosPage = () => {

    const [frmEdit, setFrmEdit] = useState(false)
    const [idEvento, setIdEvento] = useState("")
    const [name, setName] = useState("")
    const [description, setDescription] = useState("")
    const [eventType, setEventType] = useState("")//função cadastrar (objeto)
    const [date, setDate] = useState("")
    const [instituicao, setInstituicao] = useState("")
    const [tiposDeEventos, setTiposDeEventos] = useState([])//Para gerar o select (array)
    const [eventos, setEventos] = useState([])//array
    const [notifyUser, setNotifyUser] = useState({})
    const [showSpinner, setShowSpinner] = useState(false)

    useEffect(() => {
        async function getEvents() {
            setShowSpinner(true)
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
                console.log(tiposDeEventos);
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
            setShowSpinner(false)
        }
        getEvents()
    }, [])
    async function showUpdateForm(idEvent) {
        setFrmEdit(true);
        setShowSpinner(true)
        try {
            const retorno = await api.get(`/Evento/${idEvent}`)
            setName(retorno.data.nomeEvento)
            setDescription(retorno.data.descricao)
            setEventType(retorno.data.idTipoEvento)
            setDate(viewToDateFormatDb(retorno.data.dataEvento))
            setIdEvento(idEvent)
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: `Ocorreu algo de errado, verifique sua conexão internet!`,
                imgIcon: "danger",
                imgAlt:
                    "",
                showMessage: true,
            });
            console.log(error);
        }
        setShowSpinner(false)
    }
    async function handleDelete(id) {
        setShowSpinner(true)
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
        setShowSpinner(false)
        setNotifyUser({
            titleNote: "Sucesso",
            textNote: `Deletado com sucesso!`,
            imgIcon: "success",
            imgAlt:
                "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
            showMessage: true,
        });
    }
    async function handleUpdate(e) {
        e.preventDefault();
        setShowSpinner(true)
        try {
            const retorno = await api.put(`/Evento/${idEvento}`, {
                nomeEvento: name, 
                descricao: description, 
                idTipoEvento: eventType, 
                dataEvento: date, 
                idInstituicao: instituicao
            })

            const retornoGet = await api.get('/Evento')
            setEventos(retornoGet.data)

            editActionAbort()
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: `Ocorreu algo de errado ao atualizar, verifique sua conexão internet!`,
                imgIcon: "warning",
                imgAlt:
                    "",
                showMessage: true,
            });
        }
        setShowSpinner(false)

        setNotifyUser({
            titleNote: "Sucesso",
            textNote: `Atualizado com sucesso!`,
            imgIcon: "success",
            imgAlt:
                "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
            showMessage: true,
        });
    }
    async function handleSubmit(e) {
        e.preventDefault();

        if (name.trim().length < 3) {
            alert("O título precisa ter mais de 3 letras!")
        }

        setShowSpinner(true)
        try {
            const retorno = await api.post("/Evento/", { nomeEvento: name, descricao: description, idTipoEvento: eventType, dataEvento: date, idInstituicao: instituicao })
            const retornoGet = await api.get('/Evento')
            setEventos(retornoGet.data)
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: `Ocorreu algo de errado ao cadastrar, verifique sua conexão internet!`,
                imgIcon: "warning",
                imgAlt:
                    "",
                showMessage: true,
            });
        }
        setShowSpinner(false)

        setNotifyUser({
            titleNote: "Sucesso",
            textNote: `Cadastrado com sucesso!`,
            imgIcon: "success",
            imgAlt:
                "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
            showMessage: true,
        });
    }
    async function editActionAbort() {
        setFrmEdit(false);
        try {
            setName("")
            setDescription("")
            setEventType("")
            setDate("")
            setIdEvento("")
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: `Ocorreu algo de errado, verifique sua conexão internet!`,
                imgIcon: "danger",
                imgAlt:
                    "",
                showMessage: true,
            });
            console.log(error);
        }
    }



    //*************************************************************************************
    return (
        <MainContent>
            <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
            {showSpinner ? <Spinner/> : null}

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
                                        dados={tiposDeEventos}
                                        id={"TipoEvento"}
                                        name={"TipoEvento"}
                                        required={"required"}
                                        manipulationFunction={(p) => {
                                            setEventType(p.target.value)
                                        }}
                                        defaultValue={eventType}
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
                                        textButton={"Cadastrar"}
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
                                        dados={tiposDeEventos}
                                        id={"TipoEvento"}
                                        name={"TipoEvento"}
                                        required={"required"}
                                        manipulationFunction={(p) => {
                                            setEventType(p.target.value)
                                        }}
                                        defaultValue={eventType}
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
                                            textButton={"Atualizar"}
                                            type={"submit"}
                                            id={"Button-Update"}
                                            name={"Button-Update"}
                                            additionalclass={"button-component--middle"}
                                        />

                                        <Button
                                            textButton={"Cancelar"}
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