import { jwtDecode } from "jwt-decode";
import { createContext } from "react"
export const UserContext = createContext(null);

export const UserDecodeToken = (theToken) => {
    const decoded = jwtDecode(theToken)// retorna o payload do token

    return {
        role: decoded.role, 
        name: decoded.name, 
        id: decoded.jti, 
        token: theToken }
}