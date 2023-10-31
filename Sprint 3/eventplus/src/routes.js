import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import HomePage from "./pages/HomePage/HomePage";
import TipoEventosPage from './pages/TipoEventosPage/TipoEventosPage';
import EventosPage from './pages/EventosPage/EventosPage'
import LoginPage from './pages/LoginPage/LoginPage';
import TestePage from './pages/TestePage/TestePage';


const routes = () => {
    return (
        <div>
            <BrowserRouter>
                <Routes>
                    <Route element= {<HomePage />} path='/'/>
                    <Route element= {<TipoEventosPage />} path='/TipoDeEventos'/>
                    <Route element= {<EventosPage />} path='/Eventos'/>
                    <Route element= {<LoginPage />} path='/Login'/>
                    <Route element= {<TestePage />} path='/Teste'/>
                </Routes>
            </BrowserRouter>
        </div>
    );
};

export default routes;