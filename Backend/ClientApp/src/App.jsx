import { useState } from 'react'
import './App.css'

export default function App() {
  const [activeTab, setActiveTab] = useState('balance')

  return (
    <div className="app-container">
      {/* Сайдбар с навигацией */}
      <div className="sidebar">
        <h1 className="sidebar-title">Управление складом</h1>
        
        <div className="nav-section">
          <h2 className="nav-section-title">Склад</h2>
          <nav className="nav-links">
            <button 
              className={`nav-link ${activeTab === 'balance' ? 'active' : ''}`}
              onClick={() => setActiveTab('balance')}
            >
              Баланс
            </button>
            <button 
              className={`nav-link ${activeTab === 'incoming' ? 'active' : ''}`}
              onClick={() => setActiveTab('incoming')}
            >
              Поступления
            </button>
            <button 
              className={`nav-link ${activeTab === 'outgoing' ? 'active' : ''}`}
              onClick={() => setActiveTab('outgoing')}
            >
              Отгрузки
            </button>
          </nav>
        </div>

        <div className="nav-section">
          <h2 className="nav-section-title">Справочник</h2>
          <nav className="nav-links">
            <button 
              className={`nav-link ${activeTab === 'clients' ? 'active' : ''}`}
              onClick={() => setActiveTab('clients')}
            >
              Клиенты
            </button>
            <button 
              className={`nav-link ${activeTab === 'units' ? 'active' : ''}`}
              onClick={() => setActiveTab('units')}
            >
              Единицы измерения
            </button>
            <button 
              className={`nav-link ${activeTab === 'resources' ? 'active' : ''}`}
              onClick={() => setActiveTab('resources')}
            >
              Ресурсы
            </button>
          </nav>
        </div>
      </div>

      {/* Основное содержимое */}
      <main className="content">
        {activeTab === 'balance' && (
          <div className="page">
            <h2>Таблица баланса</h2>
            <p>Здесь будет содержимое раздела "Баланс"</p>
          </div>
        )}
        
        {/* Аналогичные блоки для других разделов */}
        {activeTab === 'incoming' && <div className="page"><h2>Поступления</h2><p>Содержимое</p></div>}
        {activeTab === 'outgoing' && <div className="page"><h2>Отгрузки</h2><p>Содержимое</p></div>}
        {activeTab === 'clients' && <div className="page"><h2>Клиенты</h2><p>Содержимое</p></div>}
        {activeTab === 'units' && <div className="page"><h2>Единицы измерения</h2><p>Содержимое</p></div>}
        {activeTab === 'resources' && <div className="page"><h2>Ресурсы</h2><p>Содержимое</p></div>}
      </main>
    </div>
  )
}