import React from 'react';
import './TipoEventosPage.css'
import Title from '../../components/Title/Title';
import MainContent from '../../components/MainContent/MainContent';
import Container from '../../components/Container/Container'
import ImageIllustartor from '../../components/ImageIllustartor/ImageIllustartor';
import eventTypeImage from '../../assets/images/tipo-evento.svg'
import { Input } from '../../components/FormComponents/FormComponents';

const TipoEventos = () => {
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
                        <form>
                            <p>Formulário</p>
                            <Input
                                type={"number"}
                                required={"required"}
                            />
                        </form>
                    </div>
                </Container>
            </section>
        </MainContent>
    );
};

export default TipoEventos;