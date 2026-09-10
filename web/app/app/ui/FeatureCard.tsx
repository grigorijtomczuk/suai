type FeatureCardProps = Readonly<{
  title: string;
  description: string;
}>;

export default function FeatureCard({
  title,
  description,
}: FeatureCardProps) {
  return (
    <article className="feature-card">
      <span className="feature-card__marker" aria-hidden="true" />
      <h3>{title}</h3>
      <p>{description}</p>
    </article>
  );
}
