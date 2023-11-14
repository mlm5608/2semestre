import React from 'react';
import { useState } from 'react';
import './TipoEventosPage.css'
import Title from '../../components/Title/Title';
import MainContent from '../../components/MainContent/MainContent';
import Container from '../../components/Container/Container'
import ImageIllustartor from '../../components/ImageIllustartor/ImageIllustartor';
import eventTypeImage from '../../assets/images/tipo-evento.svg'
import { Button, Input } from '../../components/FormComponents/FormComponents';
import api from '../../Services/Service'
import Titulo from '../../components/Title/Title';


const TipoEventos = () => {

    const [frmEdit, setFrmEdit] = useState(true)
    const [title, setTitle] = useState("")

    async function handleSubmit(e) {
        //parar o submit do form
        e.preventDefault();
        //validar pelo menos 3 caracteres
        if (title.trim().length < 3) {
            alert("O título precisa ter mais de 3 letras!")
            return
        }
        //chamar api
        try {
            const retorno = await api.post("/TiposEvento", {titulo: title})
            console.log("Cadastrado com sucesso");
            console.log(retorno.data);
            setTitle("")
        } catch (error) {
            console.log("deu ruim na api");
            console.log(error);
        }
    }
    function handleUpdate() {
        alert("bora atualizar")
    }

    return (
        <MainContent>
            <section className='cadastro-evento-section'>
                <Container>
                    <div className="cadastro-evento__box">
                        <Title titleText={"Página de Tipos de Evento"} />
                        <ImageIllustartor
                            imageRender={eventTypeImage}
                            alterText={""}

                        />

                        <form onSubmit={frmEdit ? handleUpdate : handleSubmit} className="ftipo-evento">
                            {!frmEdit
                                ?
                                (<>
                                    <Input
                                        type={"text"}
                                        id={"Titulo"}
                                        name={"Titulo"}
                                        placeholder={"Titulo"}
                                        required={"required"}
                                        value={title}
                                        manipulationFunction={
                                            (e) => {
                                                setTitle(e.target.value)
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
                                    <Input
                                        type={"text"}
                                        id={"Titulo"}
                                        name={"Titulo"}
                                        placeholder={"Titulo"}
                                        required={""}
                                        value={""}
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
                                            manipulationFunction={() => { setFrmEdit(false) }}
                                        />
                                    </div>
                                </>


                                )
                            }
                        </form>
                    </div>
                </Container>
            </section>
        </MainContent>
    );
};

export default TipoEventos;