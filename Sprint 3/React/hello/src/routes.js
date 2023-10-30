import React from 'react';
//import componentes de rota
import { BrowserRouter, Routes, Route} from 'react-router-dom';

//import das paginas
import HomePage from './pages/HomePage/HomePage';
import LoginPage from './pages/LoginPage/LoginPage';
import ProductPage from './pages/ProductPage/ProductPage';

const Rotas = () => {
    return (
        // criar a estrutura de rotas
        <BrowserRouter>
            <Routes>
                <Route element={<HomePage />} path="/" exact/>
                <Route element={<LoginPage />} path="/Login" exact/>
                <Route element={<ProductPage />} path="/Produtos" exact/>
            </Routes>
        </BrowserRouter>
    );
};

export default Rotas;