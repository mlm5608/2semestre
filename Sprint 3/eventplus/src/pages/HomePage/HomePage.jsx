import React from 'react';
import './HomePage.css'
import Title from '../../components/Title/Title';
import MainContent from '../../components/MainContent/MainContent';
import Banner from '../../components/Banner/Banner';
import VisionSection from '../../components/VisionSection/VisionSection'

const HomePage = () => {
    return (
        <MainContent>
            {/* <Title titleText="Página Home" additionalClass="margem-acima"/> */}
            <Banner/>

            <VisionSection/>
        </MainContent>
    );
};

export default HomePage;