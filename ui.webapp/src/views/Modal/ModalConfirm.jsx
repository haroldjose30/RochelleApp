import React from 'react';
import PropTypes from 'prop-types';

import {
    Button,
    Modal, 
    ModalHeader, 
    ModalFooter, 
  } from 'reactstrap';

const ModalConfirm = props => {

    const onSucessClick = () => {
      props.onToggle();
      props.onSucessClick();
    }

    const onDangerClick = () => {
      props.onToggle();
      props.onSucessClick();
    }

    return <div>
                <Modal isOpen={props.isOpen} toggle={props.onToggle} className='ModalConfirm' backdrop={true}>
                <ModalHeader>
                  {props.title} 
                </ModalHeader>
                <ModalFooter>
                  <Button color="sucess" onClick={onSucessClick}>{props.sucess}</Button>{' '}
                  <Button color="danger" onClick={onDangerClick}>{props.danger}</Button>
                </ModalFooter>
              </Modal>
          </div>



          
  }
 
  ModalConfirm.propTypes = {
    isOpen: PropTypes.bool,
    title: PropTypes.string,
    sucess: PropTypes.string,
    danger: PropTypes.string,
    onToggle: PropTypes.func,
    onSucessClick: PropTypes.func,
    onDangerClick: PropTypes.func,
  };
  
  ModalConfirm.defaultProps = {
    isOpen: false,
    title: '',
    sucess: 'Sim',
    danger: 'Não',
    onToggle: () => {},
    onSucessClick: () => {},
    onDangerClick: () => {},
  };
  
  export default ModalConfirm; 