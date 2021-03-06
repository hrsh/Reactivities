import React, { useState, useEffect, Fragment } from 'react';
import './styles.css';
import axios from 'axios';
import 'semantic-ui-css/semantic.min.css'
import { Container } from 'semantic-ui-react';
import { IActivity } from '../models/activity';
import { NavBar } from '../../features/nav/NavBar';
import { ActivityDashboard } from '../../features/activities/dashboard/ActivityDashboard';


const App = () => {
  const [activities, setActivities] = useState<IActivity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<IActivity | null>(null);

  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities.filter(a => a.id === id)[0])
  }

  useEffect(() => {
    axios.get<IActivity[]>('https://localhost:5001/api/activity')
      .then((response) => {
        setActivities(response.data)
      })
  }, [])

  return (
    <Fragment>
      <NavBar />
      <Container style={{ marginTop: '7em' }}>
        <ActivityDashboard
          activities={activities}
          selectActivity={handleSelectActivity}
          selectedActivity={selectedActivity!} />
      </Container>
    </Fragment>
  );
}

export default App;
