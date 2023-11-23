import "./TableEv.css"
import editPen from '../../../assets/images/edit-pen.svg'
import trashDelete from '../../../assets/images/trash-delete.svg'

const TableEv = ({ dados, fnUpdate, fnDelete }) => {
    return (
        <table className='table-data'>
            <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">Nome</th>
                    <th className="table-data__head-title table-data__head-title--big">Descrição</th>
                    <th className="table-data__head-title table-data__head-title--big">Tipo Evento</th>
                    <th className="table-data__head-title table-data__head-title--big">Data</th>
                    <th className="table-data__head-title table-data__head-title--little">Editar</th>
                    <th className="table-data__head-title table-data__head-title--little">Deletar</th>
                </tr>
            </thead>

            <tbody>
                {dados.map((ev) => {
                    return (
                        <tr className="table-data__head-row" key={ev.idEvento}>
                            <td className="table-data__data table-data__data--big" >
                                {ev.nomeEvento}
                            </td>

                            <td className="table-data__data table-data__data--big">
                                {ev.descricao}
                            </td>

                            <td className="table-data__data table-data__data--big">
                                {ev.tiposEvento.titulo}
                            </td>
                            <td className="table-data__data table-data__data--big">
                                {new Date(ev.dataEvento).toLocaleDateString()}
                            </td>

                            <td className="table-data__data table-data__data--little">
                                <img className="table-data__icon" src={editPen} alt="Imagem de caneta, para editar cadastro" onClick={() => { fnUpdate(ev.idEvento) }} />
                            </td>

                            <td className="table-data__data table-data__data--little">
                                <img className="table-data__icon" src={trashDelete} alt="Imagem de Lata de lixo, para deletar cadastro" onClick={() => { fnDelete(ev.idEvento) }} />
                            </td>
                        </tr>
                    );
                })}
            </tbody>
        </table>
    );
};

export default TableEv;