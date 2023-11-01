import React from 'react';
import { Link } from 'react-router-dom';
import './Nav.css'
import LogoMobile from '../../assets/images/logo-white.svg'
import LogoDesktop from '../../assets/images/logo-pink.svg'


const Nav = () => {
    return (
        <nav className='navbar'>
            <span className='navbar__close'>X</span>
            <Link to="/">
                <img 
                className='eventlogo__logo-image' 
                src={window.innerWidth >= 992 ? LogoDesktop : LogoMobile} 
                alt="Event Plus logo" />
            </Link>

            <div className='navbar__items-box'>
                <Link to="/">Home</Link>
                <Link to="/TipoDeEventos">Tipo Eventos</Link>
                <Link to="/Eventos">Eventos</Link>
                <Link to="/Login">Login</Link>
            </div>
        </nav>
    );
};

export default Nav;