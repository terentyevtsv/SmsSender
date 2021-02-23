import logo from './logo.svg';
import './App.css';
import SmsCreator from './components/SmsCreator';

function App() {
  return (
    <div className="App">
      <div className="wrapper">
        <h1>Отправка сообщений</h1>
        <div className="full-container">
          <section className="sms-form-container">
            <h2 className="visually-hidden">Форма отправки сообщения</h2>
            <SmsCreator/>
          </section>
          <section className="sms-list-container">
            <h2 className="visually-hidden">Список отправленных сообщений</h2>
            <table className="sms-list">
              <th>
                <td className="cell-item">Дата и время отправки</td>
                <td className="cell-item">Номер получателя</td>
                <td className="cell-item">Текст сообщения</td>
                <td className="cell-item">Статус сообщения</td>
              </th>            
            </table>
          </section>
        </div>
        
      </div>
    </div>
  );
}

export default App;
