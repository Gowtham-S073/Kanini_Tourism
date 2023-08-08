import * as React from 'react';
import { styled } from '@mui/material/styles';
import ArrowForwardIosSharpIcon from '@mui/icons-material/ArrowForwardIosSharp';
import MuiAccordion from '@mui/material/Accordion';
import MuiAccordionSummary from '@mui/material/AccordionSummary';
import MuiAccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import Hero from '../Hero/Hero';
import Recommend from '../Hero/Recommend';

const AccordionContainer = styled('div')({
  padding: '40px',
});

const Accordion = styled((props) => (
  <MuiAccordion disableGutters elevation={0} square {...props} />
))(({ theme }) => ({
  border: `1px solid ${theme.palette.divider}`,
  '&:not(:last-child)': {
    borderBottom: 0,
  },
  '&:before': {
    display: 'none',
  },
}));

const AccordionSummary = styled((props) => (
  <MuiAccordionSummary
    expandIcon={<ArrowForwardIosSharpIcon sx={{ fontSize: '0.9rem' }} />}
    {...props}
  />
))(({ theme }) => ({
  backgroundColor:
    theme.palette.mode === 'dark'
      ? 'rgba(255, 255, 255, .05)'
      : 'rgba(0, 0, 0, .03)',
  flexDirection: 'row-reverse',
  '& .MuiAccordionSummary-expandIconWrapper.Mui-expanded': {
    transform: 'rotate(90deg)',
  },
  '& .MuiAccordionSummary-content': {
    marginLeft: theme.spacing(1),
  },
}));

const AccordionDetails = styled(MuiAccordionDetails)(({ theme }) => ({
  padding: theme.spacing(2),
  borderTop: '1px solid rgba(0, 0, 0, .125)',
}));

export default function CustomizedAccordions() {
  const [expanded, setExpanded] = React.useState('panel1');

  const handleChange = (panel) => (event, newExpanded) => {
    setExpanded(newExpanded ? panel : false);
  };

  return (
    <>
    <Hero></Hero>
    <Recommend></Recommend>
    <AccordionContainer>
      <h1>FAQs</h1>
      <Accordion expanded={expanded === 'panel1'} onChange={handleChange('panel1')}>
        <AccordionSummary aria-controls="panel1d-content" id="panel1d-header">
          <Typography>WHY SHOULD I USE A TRAVEL AGENT TO BOOK A VACATION?</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Typography>
            A travel agent takes all of the headache out of planning a trip and handles virtually all aspects of your travel, at absolutely no cost to you. The combined experience of the team and the feedback from our thousands of travelers provides an invaluable resource to the traveler planning an important trip.

            In recent years, the top travel vendors have empowered and trained the agency community to be even more effective and efficient go-betweens
          </Typography>
        </AccordionDetails>
      </Accordion>
      <Accordion expanded={expanded === 'panel2'} onChange={handleChange('panel2')}>
        <AccordionSummary aria-controls="panel2d-content" id="panel2d-header">
          <Typography>CAN YOU WORK WITHIN A CERTAIN BUDGET?</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Typography>
            Yes, we work within any and all realistic budgets, and an honest sharing of ideas and goals helps us immensely when making recommendations and suggested edits to travel plans.
          </Typography>
        </AccordionDetails>
      </Accordion>
      <Accordion expanded={expanded === 'panel3'} onChange={handleChange('panel3')}>
        <AccordionSummary aria-controls="panel3d-content" id="panel3d-header">
          <Typography>DOES IT COST MONEY TO GET A QUOTE?</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Typography>
            No, there is no fee for our vacation planning services as the travel vendors involved recognize our value and compensate us from the gross amount paid (what you would have paid even without our assistance). For those complicated international itineraries that require custom crafting and significant involvement of our international on-location partners, we do request an intent-to-travel deposit to begin the process. This deposit is applied to the reservations that are made on your behalf.
          </Typography>
        </AccordionDetails>
      </Accordion>
      <Accordion expanded={expanded === 'panel4'} onChange={handleChange('panel4')}>
        <AccordionSummary aria-controls="panel4d-content" id="panel4d-header">
          <Typography>WHERE CAN I FIND MY ITINERARY ONCE MY TRIP IS BOOKED?</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Typography>
          Your itinerary as booked by Professional Travel a Direct Travel Company is available on our View Trip website with your specific reservation code as the login. Since we are directly connected to vendors’ inventory systems (airlines, cruise lines, hotels, cars, rail, etc.), you will also be able to retrieve your information on their unique client sites, many of which offer a wealth of information to help you prepare for the trip ahead.
          </Typography>
        </AccordionDetails>
      </Accordion>
    </AccordionContainer>
    </>
  );
}
