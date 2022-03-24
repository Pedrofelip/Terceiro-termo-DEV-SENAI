import React from "react";
import ReactDOM from 'react-dom';
import './styles.css';

const portalRoot = document.getElementById('portal-root');

const UIModal = ({ children, isOpen }) => {
    if (!isOpen) {
        return null;
    }
    
    return ReactDOM.createPortal(
        <div className="ui-modal__overlay">
            <div className="ui-modal">
                {children}
            </div>
        </div>,
        portalRoot,
    );
};

export default UIModal;