using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathFunctions
{
    /*
    Happiness gain should generally not be higher than 100 or lower than -100. Voters want sentiment to match their bias, thus voter's biases
    are tied to the highest value of happiness (*happinessGainCap*, *bias*). The vertex of a parabola is always x = 100, y = bias. The leading quadratic coefficient
    is *radicalization*. Radicalization determines the width of the parabola and is always negative so that the vertex is at the top. The larger the number
    of radicalization the less happiness a player gets for being distant from the voter's bias.

    Since y = bias, sentiment must be compared to y. 
    */
    public static float VoterParabola(Vector2 happinessVertex, float inputRadical)
    {
        /* - Finding the Quadratic Formula - */
        //y = a(ax-h)^2 + k
        //y = ax^2 + bx + c
        // h = happiness, k = bias
        //a determines direction up or down based on negative or positive. larger number the tigher the parabola and vise versa
        var firstStep = 2 * -Mathf.Abs(inputRadical); //make sure the input radical is always negative

        var linearCoef = firstStep * happinessVertex.x;

        //f(happinessVertex.x) = inputRadical(happinessVertex.x) + linearCoef(happinessVertex.x) + c = happinessVertex.y
        var secondStep = inputRadical * happinessVertex.x + linearCoef * happinessVertex.x;

        var thirdStep = 0f;
        //ensure that the transposition is using the correct value, negative or positive 
        if (secondStep < 0)
        {
            thirdStep = Mathf.Abs(secondStep);
        } else if (secondStep > 0)
        {
            thirdStep = -Mathf.Abs(inputRadical);
        }

        var constTerm = thirdStep + happinessVertex.y;

        /* - Creating the Parabola - */

        return constTerm;
    }
}
