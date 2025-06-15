/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Interface for all interactable objects. Requires Interact, Highlight, and Unhighlight methods.
 */

/// <summary>
/// Interface that all interactable objects must implement.
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// Called when the player interacts with the object.
    /// </summary>
    void Interact();

    /// <summary>
    /// Called when the player is looking at the object (e.g., to apply highlight effect).
    /// </summary>
    void Highlight();

    /// <summary>
    /// Called when the player looks away from the object (e.g., to remove highlight effect).
    /// </summary>
    void Unhighlight();
}

