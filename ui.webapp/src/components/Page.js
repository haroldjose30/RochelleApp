import React from 'react';
import PropTypes from '../utils/propTypes';
import bn from '../utils/bemnames';
import { Breadcrumb, BreadcrumbItem,Alert } from 'reactstrap';
import Typography from './Typography';
import Loading from './Loading';

const bem = bn.create('page');

const Page = ({
  title,
  breadcrumbs,
  tag: Tag,
  className,
  children,
  alertMessage,
  alertColor,
  loading,
  ...restProps,
}) => {
  const classes = bem.b('px-3', className);

  return (
    <Tag className={classes} {...restProps}>
      <div className={bem.e('header')}>
        {title && typeof title === 'string' ? (
          <Typography type="h1" className={bem.e('title')}>
            {title} 
          </Typography>
        ) : (
            title
          )}
        {breadcrumbs && (
          <Breadcrumb className={bem.e('breadcrumb')}>
            <BreadcrumbItem>Principal</BreadcrumbItem>
            {breadcrumbs.length &&
              breadcrumbs.map(({ name, active }, index) => (
                <BreadcrumbItem key={index} active={active}>
                  {name}
                </BreadcrumbItem>
              ))}
          </Breadcrumb>
        )}
       
        <Loading loading={loading}/>
        
      </div>
      
      <Alert isOpen={alertMessage.length >0} color={alertColor}>
       {alertMessage}
      </Alert>
      
      {children}
    </Tag>
  );
};

Page.propTypes = {
  tag: PropTypes.component,
  title: PropTypes.oneOfType([PropTypes.string, PropTypes.element]),
  className: PropTypes.string,
  alertMessage:PropTypes.string,
  alertColor:PropTypes.string,
  children: PropTypes.node,
  loading: PropTypes.bool,
  breadcrumbs: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string,
      active: PropTypes.bool,
    })
  ),
};

Page.defaultProps = {
  tag: 'div',
  title: '',
  alertMessage: '',
  alertColor:'danger',
  loading:false,
};

export default Page;
