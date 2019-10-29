import React from 'react';
import PropTypes from 'prop-types';
import loadingGif from '../assets/gif/loading.gif'

const Loading = props => {
  return (
    <div  hidden={!props.loading}>
      {props.message}
      <img width="50" src={loadingGif} alt="loading..."/>
    </div>
  );
};

Loading.propTypes = {
  message: PropTypes.string,
  isVisible: PropTypes.bool,
};

Loading.defaultProps = {
    message: '',
    loading:false,
};

export default Loading;
