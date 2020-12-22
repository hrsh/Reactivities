import React from 'react'
import { Button, ButtonGroup, Card, Icon, Image } from 'semantic-ui-react'
import { IActivity } from '../../../app/models/activity'

interface IProps {
    activity: IActivity
}

export const ActivityDetails: React.FC<IProps> = ({ activity }) => {
    return (
        <Card fluid>
            <Image src='https://react.semantic-ui.com/images/avatar/large/matthew.png' wrapped ui={false} />
            <Card.Content>
                <Card.Header>{activity.title}</Card.Header>
                <Card.Meta>
                    <span>{activity.date}</span>
                </Card.Meta>
                <Card.Description>
                    {activity.description}
                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <ButtonGroup widths={2}>
                    <Button color='violet' icon labelPosition='left'>
                        <Icon name='pencil' />
                        Update
                    </Button>
                    <Button color='grey' icon labelPosition='right'>
                        <Icon name='reply' />
                        Cancel
                    </Button>
                </ButtonGroup>
            </Card.Content>
        </Card>
    )
}
