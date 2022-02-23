using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathFunctions
{
    /*
    Happiness gain should generally not be higher than 100 or lower than -100. Voters want sentiment to match their bias, thus voter's biases
    are tied to the highest value of happiness (*bias*, *happinessGainCap*). The vertex of a parabola is always x = bias, y = *happinessGainCap*. The leading quadratic coefficient
    is *radicalization*. Radicalization determines the width of the parabola and is always negative so that the vertex is at the top. The larger the number
    of radicalization the less happiness a player gets for being distant from the voter's bias.

    Since x is the scale for bias, x = sentiment. 
    */
    public static float VoterParabola(Vector2 happinessVertex, float inputRadical, float sentiment)
    {
        /* - Finding the Quadratic Formula - */
        //y = a(x-h)^2 + k
        //y = inputRadical(x-happinessVertex.x)^2 + happinessVertex.y
        //y = ax^2 + bx + c
        //h = happiness, k = bias
        //a determines direction up or down based on negative or positive. larger number the tigher the parabola and vise versa
        var quadCoef = -Mathf.Abs(inputRadical); //make sure the input radical is always negative

        var outputHappiness = quadCoef * Mathf.Pow((sentiment - happinessVertex.x), 2) + happinessVertex.y;

        if (outputHappiness < -100)
        {
            outputHappiness = -100;
        }

        return outputHappiness;
    }
}
