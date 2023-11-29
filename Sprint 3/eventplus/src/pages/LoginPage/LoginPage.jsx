import React, { useContext, useState } from "react";
import ImageIllustrator from "../../components/ImageIllustartor/ImageIllustartor";
import logo from "../../assets/images/logo-pink.svg";
import loginImage from "../../assets/images/login.svg"
import { Input, Button } from "../../components/FormComponents/FormComponents";
import api from "../../Services/Service"
import { UserContext, UserDecodeToken } from "../../Context/AuthContext";

import "./LoginPage.css";

const LoginPage = () => {
    const [user, setUser] = useState({ email: "miguelmoreira5608@gmail.com", senha: "12345" })
    //Dados Globais do usuario
    const {userData, setUserData} = useContext(UserContext)

    async function handleSubmit(e) {
        e.preventDefault()
        if (user.email.length >= 3 && user.senha.length >= 3) {
            try {
                const promise = await api.post(`/Login`, {
                    email: user.email,
                    senha: user.senha
                })
                const userFullToken = UserDecodeToken(promise.data.token)

                setUserData(userFullToken) //guarda os dados decodificadosc(payload)
                localStorage.setItem("token", JSON.stringify(userFullToken));

            } catch (error) {
                alert(error)
            }
        } else {
            alert("deu ruim")
        }
    }

    return (
        <div className="layout-grid-login">
            <div className="login">
                <div className="login__illustration">
                    <div className="login__illustration-rotate"></div>
                    <ImageIllustrator
                        imageRender={loginImage}
                        altText="Imagem de um homem em frente de uma porta de entrada"
                        additionalClass="login-illustrator "
                    />
                </div>

                <div className="frm-login">
                    <img src={logo} className="frm-login__logo" alt="" />

                    <form className="frm-login__formbox" onSubmit={handleSubmit}>
                        <Input
                            className="frm-login__entry"
                            type="email"
                            id="login"
                            name="login"
                            required={true}
                            value={user.email}
                            manipulationFunction={(e) => {
                                setUser({
                                    ...user,
                                    email: e.target.value
                                })
                             }}
                            placeholder="Username"
                        />

                        <Input
                            className="frm-login__entry"
                            type="password"
                            id="senha"
                            name="senha"
                            required={true}
                            value={user.senha}
                            manipulationFunction={(e) => { 
                                setUser({
                                    ...user,
                                    senha: e.target.value
                                })
                            }}
                            placeholder="****"
                        />

                        <a href="" className="frm-login__link">
                            Esqueceu a senha?
                        </a>

                        <Button
                            text="Login"
                            id="btn-login"
                            name="btn-login"
                            type="submit"
                            className="frm-login__button"
                        />
                    </form>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;

