import React, { useRef } from 'react';
import axios from 'axios';

const CustomerForm = ({ fetchCustomers, show, setShow}) => {
  const formRef = useRef(null);

  const onSubmit = async (event) => {
    event.preventDefault();
    const formData = new FormData(event.target);
    const data = {};
    formData.forEach((value, key) => {
      data[key] = value;
    });

    try {
      await axios.post(`${process.env.REACT_APP_API_URL}/Customer`, data);
      fetchCustomers();
      formRef.current.reset(); // Función para limpiar los campos luego de guardar.
      setShow(false);
    } catch (error) {
      console.error('Error al crear el cliente:', error);
    }
  };

  return (
    <div className="customer-form">
      <h2>Crear Nuevo Cliente</h2>
      <form onSubmit={onSubmit} ref={formRef}>
        <div className="form-group">
          <label>Nombre:</label>
          <input type="text" name="name" required />
        </div>
        <div className="form-group">
          <label>Apellido:</label>
          <input type="text" name="lastName" required />
        </div>
        <div className="form-group">
          <label>Email:</label>
          <input type="email" name="email" required />
        </div>
        <div className="form-group">
          <label>Identificación:</label>
          <input type="text" name="identification" required />
        </div>
        <div className="form-group">
          <label>Teléfono:</label>
          <input type="text" name="phone" required />
        </div>
        <div className="form-group">
          <label>Dirección:</label>
          <input type="text" name="address" required />
        </div>
        <div className="form-group">
          <label>Género:</label>
          <input type="text" name="gender" required />
        </div>
        <div className="form-group">
          <label>Fecha de Nacimiento:</label>
          <input type="date" name="birthday" required />
        </div>
        <button type="submit">Crear</button>
        <button onClick={() => setShow(false)} 
          style={{ backgroundColor: 'red', color: 'white' }}
        >Cancelar</button>
      </form>
    </div>
  );
};

export default CustomerForm;