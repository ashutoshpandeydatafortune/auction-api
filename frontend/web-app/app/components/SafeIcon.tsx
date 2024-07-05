import React from 'react';

// Define the props expected by SafeIcon
interface SafeIconProps {
    icon: React.ElementType;  // This allows passing any React component type
    className?: string;
}

// SafeIcon component definition
const SafeIcon: React.FC<SafeIconProps> = ({ icon: Icon, ...props }) => {
    // Assume positionInGroup is being destructured elsewhere or not passed to DOM elements
    const { className } = props;
    return <Icon className={className} />;
};

export default SafeIcon;
