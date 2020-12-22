import React from 'react'
import { Button, Container, Menu } from 'semantic-ui-react'

export const NavBar = () => {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src="/logo192.png" alt="Reactivities" style={{ marginRight: '10px' }} />
                    Reactivities
                </Menu.Item>
                <Menu.Item name='Activities' />
                <Menu.Item>
                    <Button positive content='Create new activity' />
                </Menu.Item>
            </Container>
        </Menu>
    )
}
