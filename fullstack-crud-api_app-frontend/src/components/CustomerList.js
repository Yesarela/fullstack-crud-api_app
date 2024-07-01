import React, { useState } from 'react';
import axios from 'axios';
import Modal from 'react-modal';

Modal.setAppElement('#root');

const CustomerList = ({ customers, fetchCustomers, show, setShow }) => {
  const [searchTerm, setSearchTerm] = useState('');
  const [editingCustomer, setEditingCustomer] = useState(null);
  const [formData, setFormData] = useState({
    name: '',
    lastName: '',
    email: '',
    identification: '',
    phone: '',
    address: '',
    gender: '',
    birthday: ''
  });

  const deleteCustomer = async (id) => {
    try {
      await axios.delete(`${process.env.REACT_APP_API_URL}/Customer/${id}`);
      fetchCustomers();
    } catch (error) {
      console.error('Error al eliminar al cliente:', error);
    }
  };

  const handleEdit = (customer) => {
    setEditingCustomer(customer);
    setFormData({
      id: customer.id,
      name: customer.name,
      lastName: customer.lastName,
      email: customer.email,
      identification: customer.identification,
      phone: customer.phone,
      address: customer.address,
      gender: customer.gender,
      birthday: customer.birthday
    });
  };

  const handleCloseEdit = () => {
    setEditingCustomer(null);
    setFormData({
      name: '',
      lastName: '',
      email: '',
      identification: '',
      phone: '',
      address: '',
      gender: '',
      birthday: ''
    });
  };

  const handleInputChange = (event) => {
    setFormData({ ...formData, [event.target.name]: event.target.value });
  };

  const onSubmit = async (event) => {
    event.preventDefault();
    try {
      await axios.put(`${process.env.REACT_APP_API_URL}/Customer/${editingCustomer.id}`, formData);
      handleCloseEdit();
      fetchCustomers();
    } catch (error) {
      console.error('Error al guardar los cambios del cliente:', error);
    }
  };

  const filteredCustomers = customers.filter((customer) =>
    customer.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
    customer.lastName.toLowerCase().includes(searchTerm.toLowerCase()) ||
    customer.email.toLowerCase().includes(searchTerm.toLowerCase()) ||
    customer.identification.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="customer-list">
      <h2>Listado de Clientes</h2>
      <div style={{ 
        display: 'flex', 
        justifyContent: 'space-between', 
        alignItems: 'center', 
        marginBottom: '10px'
      }}>
      <input
        type="text"
        placeholder="Buscar cliente..."
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        style={{
  
          padding: '5px', 
        
        }}
      />

      <button onClick={() => setShow(!show)}>{show ? 'Cerrar' : 'Crear Nuevo Cliente'}</button>
      </div>
      <table>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Email</th>
            <th>Identificación</th>
            <th>Teléfono</th>
            <th>Dirección</th>
            <th>Género</th>
            <th>Fecha de Nacimiento</th>
            <th>Fecha de Registro</th>
            <th>Última Actualización</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {filteredCustomers.map((customer) => (
            <tr key={customer.id}>
              <td>{customer.name}</td>
              <td>{customer.lastName}</td>
              <td>{customer.email}</td>
              <td>{customer.identification}</td>
              <td>{customer.phone}</td>
              <td>{customer.address}</td>
              <td>{customer.gender}</td>
              <td>{customer.birthday}</td>
              <td>{customer.createdDate}</td>
              <td>{customer.lastModifiedDate}</td>
              <td className="button-group">
                <button onClick={() => handleEdit(customer)}
                  style={{
                    backgroundColor: 'skyblue',
                    color: 'white',
                    border: 'none',
                    cursor: 'pointer'
                  }}
                >Editar</button>
                <button onClick={() => deleteCustomer(customer.id)}
                  style={{
                    backgroundColor: 'red',
                    color: 'white',
                    border: 'none',
                    cursor: 'pointer'
                  }}
                >Eliminar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      {editingCustomer && (
        <Modal
          isOpen={!!editingCustomer}
          onRequestClose={handleCloseEdit}
          contentLabel="Editar Cliente"
          className="Modal"
          overlayClassName="Overlay"
        >
          <div className="customer-form">
            <h2>Editar Cliente</h2>
            <form onSubmit={onSubmit}>
              <div className="form-group">
                <label>Nombre:</label>
                <input type="text" name="name" value={formData.name} onChange={handleInputChange} required />
              </div>
              <div className="form-group">
                <label>Apellido:</label>
                <input type="text" name="lastName" value={formData.lastName} onChange={handleInputChange} required />
              </div>
              <div className="form-group">
                <label>Email:</label>
                <input type="email" name="email" value={formData.email} onChange={handleInputChange} required />
              </div>
              <div className="form-group">
                <label>Identificación:</label>
                <input type="text" name="identification" value={formData.identification} onChange={handleInputChange} required />
              </div>
              <div className="form-group">
                <label>Teléfono:</label>
                <input type="text" name="phone" value={formData.phone} onChange={handleInputChange} required />
              </div>
              <div className="form-group">
                <label>Dirección:</label>
                <input type="text" name="address" value={formData.address} onChange={handleInputChange} required />
              </div>
              <div className="form-group">
                <label>Género:</label>
                <input type="text" name="gender" value={formData.gender} onChange={handleInputChange} required />
              </div>
              <div className="form-group">
                <label>Fecha de Nacimiento:</label>
                <input type="date" name="birthday" value={formData.birthday} onChange={handleInputChange} required />
              </div>
              <div className="form-buttons">
                <button type="submit">Guardar Cambios</button>
                <button type="button" onClick={handleCloseEdit}
                  style={{ 
                    backgroundColor: 'red', 
                    color: 'white', 
                    border: 'none', 
                    cursor: 'pointer' 
                  }}
                >Cancelar</button>

              </div>
            </form>
          </div>
        </Modal>
      )}
    </div>
  );
};

export default CustomerList;